using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class MenuControles : MonoBehaviour
{
   ChangeLevelLogic level = new ChangeLevelLogic();

    public GameObject botonVolver;
    private void Start() {
     EventSystem.current.SetSelectedGameObject(botonVolver); 
    }
}
