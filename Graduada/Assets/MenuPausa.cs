using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public static bool GameIsPaused= false;
    public GameObject MenuPausaUI;

    LogicaCambioNivel cambiar = new LogicaCambioNivel();

    // Update is called once per frame
    private void Start() {
        MenuPausaUI.SetActive(false);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.U)){
            Debug.Log(GameIsPaused);
            if(GameIsPaused){
                Resume();
            }
            else{
                
                Pause();
            }
        }
    }

    private void Resume(){
      MenuPausaUI.SetActive(false);
      Time.timeScale = 1f;
      GameIsPaused = false; 
    }

    private void Pause(){
      MenuPausaUI.SetActive(true);
      Time.timeScale = 0f;
      GameIsPaused = true;
    }

    public void LoadMenu(){
       cambiar.cargarMenuPrincipal();
    }

}
