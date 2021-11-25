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
     public void ChargeButton(){
      EventSystem.current.SetSelectedGameObject(botonVolver);
    }
    private void Update() {
        if(EventSystem.current.currentSelectedGameObject==null){
        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow)
        || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.W)){
          EventSystem.current.SetSelectedGameObject(botonVolver); 
        }
      }
    }
}
