using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public static bool GameIsPaused= false;
    public GameObject MenuPausaUI;
    public LogicaCambioNivel cambiar;

    // Update is called once per frame
    void Update()
    {
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

    void Pause(){
      MenuPausaUI.SetActive(true);
      Time.timeScale = 0f;
      GameIsPaused = true;
    }

    public void LoadMenu(){
       cambiar.cargarMenuPrincipal();
    }

}
