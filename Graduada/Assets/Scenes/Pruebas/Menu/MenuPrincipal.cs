using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    // Start is called before the first frame update
    ChangeLevelLogic level = new ChangeLevelLogic();

    public GameObject botonComenzarJuego,botonCargarPartida,botonOpciones,botonVolver;

    private void Start() {
     EventSystem.current.SetSelectedGameObject(botonComenzarJuego); 
    }
    public void PlayGame(){
      level.start();
    }

    public void ChargeButton(){
      EventSystem.current.SetSelectedGameObject(botonOpciones);
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void CargarCreditos(){
       SceneManager.LoadScene(5);
    }

    private void Update() {
      if(EventSystem.current.currentSelectedGameObject==null){
        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow)
        || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.W)){
          EventSystem.current.SetSelectedGameObject(botonComenzarJuego); 
        }
      }
    }
}


