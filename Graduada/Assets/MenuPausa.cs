using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuPausa : MonoBehaviour
{
    public static bool GameIsPaused= false;
    public GameObject MenuPausaUI, MenuOpcionesUI, botonVolverJuego,botonInventario,botonOpciones,botonVolverMenu;

    LogicaCambioNivel cambiar = new LogicaCambioNivel();

    // Update is called once per frame
    private void Start() {
        MenuPausaUI.SetActive(false);
    }
    private void Update()
    {
      if(Input.GetKeyDown(KeyCode.X) &&  GameIsPaused){
       
       switch(EventSystem.current.currentSelectedGameObject.name){
         case "VolverAJugar":
         Resume();
         break;
         case "Volver":
         LoadMenu();
         break;
         case "Inventario":
         break;
         case "Opciones":

         break;
         default :
         break;
       }
      }
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(GameIsPaused){
                Resume();
            }
            else{
                Pause();
                EventSystem.current.SetSelectedGameObject(botonVolverJuego); 
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
    public void ChargeOpciones(){
      MenuPausaUI.SetActive(false);
      MenuOpcionesUI.SetActive(true);
    }

    public void Pause(){
      MenuPausaUI.SetActive(true);
      Time.timeScale = 0f;
      GameIsPaused = true;
    }

    public void LoadMenu(){
       cambiar.cargarMenuPrincipal();
       Time.timeScale = 1f;
    }

}
