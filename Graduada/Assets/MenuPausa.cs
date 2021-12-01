using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuPausa : MonoBehaviour
{
    public static bool GameIsPaused= false;
    public GameObject MenuPausaUI, botonVolverJuego,botonInventario,botonOpciones,botonVolverMenu;

    LogicaCambioNivel cambiar = new LogicaCambioNivel();

    // Update is called once per frame
    private void Start() {
        MenuPausaUI.SetActive(false);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.U)){
            if(GameIsPaused){
                Resume();
            }
            else{
                
                Pause();
            }
        }
        if(GameIsPaused){
        if(EventSystem.current.currentSelectedGameObject==null){
        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow)
        || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.W)){
          EventSystem.current.SetSelectedGameObject(botonVolverJuego); 
         }
       }
     }
    }

    public void Resume(){
      MenuPausaUI.SetActive(false);
      Time.timeScale = 1f;
      GameIsPaused = false; 
    }

    public void Pause(){
      MenuPausaUI.SetActive(true);
      EventSystem.current.SetSelectedGameObject(botonVolverJuego); 
      Time.timeScale = 0f;
      GameIsPaused = true;
    }

    public void LoadMenu(){
       cambiar.cargarMenuPrincipal();
    }

}
