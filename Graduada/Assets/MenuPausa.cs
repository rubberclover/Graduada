using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuPausa : MonoBehaviour
{
    public static bool GameIsPaused= false;
    public bool GameIsInMenuPause= true;
    public GameObject MenuPausaUI, MenuOpcionesUI, botonVolverJuego,botonInventario,botonOpciones,botonVolverMenu, cambita;

    LogicaCambioNivel cambiar = new LogicaCambioNivel();

    MenuPausaOpciones misOpciones;

    // Update is called once per frame
    private void Start() {
        MenuPausaUI.SetActive(false);
    }
    private void Update()
    {
     if(GameIsPaused && GameIsInMenuPause){
        if(EventSystem.current.currentSelectedGameObject==null){
          EventSystem.current.SetSelectedGameObject(botonVolverJuego); 
       }
     }

      if(Input.GetKey(KeyCode.X) &&  GameIsPaused && GameIsInMenuPause){
       
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
         GameIsInMenuPause = false;
         MenuOpcionesUI.SetActive(true);
         MenuPausaUI.SetActive(false);
         EventSystem.current.SetSelectedGameObject(null);
         misOpciones=cambita.GetComponent<MenuPausaOpciones>();
         misOpciones.GameIsInOptions = true;
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
