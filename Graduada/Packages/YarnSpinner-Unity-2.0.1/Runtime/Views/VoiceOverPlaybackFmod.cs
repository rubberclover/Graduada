﻿//--------------------------------------------------------------------
//
// This is a Unity behaviour script that demonstrates how to use Programmer
// Sounds and the Audio Table in your game code for the use with the yarn
// dialogue system. It has been slightly altered from this place
// originally:
// https://fmod.com/resources/documentation-unity?version=2.0&page=examples-programmer-sounds.html
//
// Programmer sounds allows the game code to receive a callback at a
// sound-designer specified time and return a sound object to the be played
// within the event.
//
// The audio table is a group of audio files compressed in a Bank that are
// not associated with any event and can be accessed by a string key.
//
// Together these two features allow for an efficient implementation of
// dialogue systems where the sound designer can build a single template
// event and different dialogue sounds can be played through it at runtime.
//
// This script will play one of three pieces of dialog through an event on
// a key press from the player.
//
// This document assumes familiarity with Unity scripting. See
// https://unity3d.com/learn/tutorials/topics/scripting for resources on
// learning Unity scripting. 
//
//--------------------------------------------------------------------
#if FMOD_2_OR_NEWER
using System;
using UnityEngine;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Collections;

namespace Yarn.Unity
{
    class VoiceOverPlaybackFmod : DialogueViewBase
    {
        FMOD.Studio.EVENT_CALLBACK dialogueCallback;

        /// <summary>
        /// The event name of the programmer's sound from the fmod studio
        /// project that we trigger voice dialogues from
        /// </summary>
        [FMODUnity.EventRef]
        public string fmodEvent = "";

        /// <summary>
        /// When true, the Runner has signaled to finish the current line
        /// asap.
        /// </summary>
        bool interrupted = false;

        /// <summary>
        /// FMOD callbacks are received via a static method. To support
        /// multiple instances of this playback class, we track the last
        /// fired FMOD event per instance here.
        /// </summary>
        FMOD.Studio.EventInstance lastVoiceOverEvent;

        /// <summary>
        /// All instances currently alive of this class. Necessary to
        /// properly deal with static callbacks from FMOD.
        /// </summary>
        static List<VoiceOverPlaybackFmod> instances = new List<VoiceOverPlaybackFmod>();

        void OnEnable()
        {
            instances.Add(this);
        }

        void OnDisable()
        {
            instances.Remove(this);
        }

        void Start()
        {
            // Explicitly create the delegate object and assign it to a
            // member so it doesn't get freed by the garbage collected
            // while it's being used
            dialogueCallback = new FMOD.Studio.EVENT_CALLBACK(DialogueEventCallback);
        }

        // TODO: There's currently no way for other parts of the system to
        // tell this object that audio has been interrupted (e.g due to the
        // user requesting to go to the next line in the middle of audio
        // playback.)

        [AOT.MonoPInvokeCallback(typeof(FMOD.Studio.EVENT_CALLBACK))]
        static FMOD.RESULT DialogueEventCallback(FMOD.Studio.EVENT_CALLBACK_TYPE type, IntPtr instancePtr, IntPtr parameterPtr)
        {
            FMOD.Studio.EventInstance instance = new FMOD.Studio.EventInstance(instancePtr);

            // Retrieve the user data
            IntPtr stringPtr;
            instance.getUserData(out stringPtr);

            // Get the string object
            GCHandle stringHandle = GCHandle.FromIntPtr(stringPtr);
            String key = stringHandle.Target as String;

            switch (type) {
                case FMOD.Studio.EVENT_CALLBACK_TYPE.CREATE_PROGRAMMER_SOUND: {
                        FMOD.MODE soundMode = FMOD.MODE.DEFAULT | FMOD.MODE.CREATESTREAM;
                        var parameter = (FMOD.Studio.PROGRAMMER_SOUND_PROPERTIES)Marshal.PtrToStructure(parameterPtr, typeof(FMOD.Studio.PROGRAMMER_SOUND_PROPERTIES));

                        if (key.Contains(".")) {
                            FMOD.Sound dialogueSound;
                            var soundResult = FMODUnity.RuntimeManager.CoreSystem.createSound(Application.streamingAssetsPath + "/" + key, soundMode, out dialogueSound);
                            if (soundResult == FMOD.RESULT.OK) {
                                parameter.sound = dialogueSound.handle;
                                parameter.subsoundIndex = -1;
                                Marshal.StructureToPtr(parameter, parameterPtr, false);
                            }
                        } else {
                            FMOD.Studio.SOUND_INFO dialogueSoundInfo;
                            var keyResult = FMODUnity.RuntimeManager.StudioSystem.getSoundInfo(key, out dialogueSoundInfo);
                            if (keyResult != FMOD.RESULT.OK) {
                                break;
                            }
                            FMOD.Sound dialogueSound;
                            var soundResult = FMODUnity.RuntimeManager.CoreSystem.createSound(dialogueSoundInfo.name_or_data, soundMode | dialogueSoundInfo.mode, ref dialogueSoundInfo.exinfo, out dialogueSound);
                            if (soundResult == FMOD.RESULT.OK) {
                                parameter.sound = dialogueSound.handle;
                                parameter.subsoundIndex = dialogueSoundInfo.subsoundindex;
                                Marshal.StructureToPtr(parameter, parameterPtr, false);
                            }
                        }
                    }
                    break;
                case FMOD.Studio.EVENT_CALLBACK_TYPE.DESTROY_PROGRAMMER_SOUND: {
                        var parameter = (FMOD.Studio.PROGRAMMER_SOUND_PROPERTIES)Marshal.PtrToStructure(parameterPtr, typeof(FMOD.Studio.PROGRAMMER_SOUND_PROPERTIES));
                        var sound = new FMOD.Sound();
                        sound.handle = parameter.sound;
                        sound.release();
                    }
                    break;
                case FMOD.Studio.EVENT_CALLBACK_TYPE.DESTROYED:
                    // Now the event has been destroyed, unpin the string
                    // memory so it can be garbage collected
                    stringHandle.Free();
                    break;
            }
            return FMOD.RESULT.OK;
        }

        public override void RunLine(LocalizedLine dialogueLine, System.Action onDialogueDeliveryComplete)
        {
            StartCoroutine(DoRunLine(dialogueLine, onDialogueDeliveryComplete));

            IEnumerator DoRunLine(LocalizedLine dialogueLine, System.Action onDialogueDeliveryComplete)
            {
                interrupted = false;

                // Check if this instance is currently playing back another
                // voice over in which case we stop it
                if (lastVoiceOverEvent.isValid())
                {
                    lastVoiceOverEvent.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                }

                // Create playback event
                FMOD.Studio.EventInstance dialogueInstance;
                try
                {
                    dialogueInstance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
                }
                catch (Exception)
                {
                    UnityEngine.Debug.LogWarning("FMOD: Voice over playback failed.", gameObject);
                    throw;
                }

                lastVoiceOverEvent = dialogueInstance;

                // Pin the key string in memory and pass a pointer through the
                // user data
                GCHandle stringHandle = GCHandle.Alloc(dialogueLine.TextID.Remove(0, 5), GCHandleType.Pinned);
                dialogueInstance.setUserData(GCHandle.ToIntPtr(stringHandle));

                dialogueInstance.setCallback(dialogueCallback, FMOD.Studio.EVENT_CALLBACK_TYPE.ALL);
                dialogueInstance.start();
                dialogueInstance.release();

                while (!interrupted && dialogueInstance.isValid())
                {
                    yield return null;
                }

                if (dialogueInstance.isValid())
                {
                    dialogueInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                }
            }
        }

        public override void OnLineStatusChanged(LocalizedLine dialogueLine)
        {
            switch (dialogueLine.Status)
            {
                case LineStatus.Presenting:
                    // Nothing to do here - continue running.
                    break;
                case LineStatus.Interrupted:
                    // The user wants us to wrap up the audio quickly. The
                    // DoPlayback coroutine will apply the fade out defined
                    // by fadeOutTimeOnLineFinish.
                    interrupted = true;
                    break;
                case LineStatus.FinishedPresenting:
                    // The line has finished delivery on all views. Nothing
                    // left to do for us, since the audio will have already
                    // finished playing out.
                    break;
                case LineStatus.Dismissed:
                    // The line is being dismissed; ensure that we
                    // interrupt the FMOD instance.
                    interrupted = true;
                    break;
            }
        }
    }
}
#endif