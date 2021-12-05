using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 using UnityEngine.Events;
 using UnityEngine.EventSystems;

public class BotonComenzar :  MonoBehaviour
{
     ChangeLevelLogic level = new ChangeLevelLogic();
GameObject currentSelected;
 
     void Update()
     {
         currentSelected = EventSystem.current.currentSelectedGameObject;
 
         if(currentSelected.name == "BotonComenzar")
         {
            if(Input.GetKeyDown(KeyCode.Return)){
            PlayGame();
        }
         }
     }
 public void PlayGame(){
      level.start();
    }
    // Update is called once per frame
}
