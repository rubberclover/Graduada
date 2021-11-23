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

    public void QuitGame(){
        Application.Quit();
    }

    private void Update() {
    }
}


