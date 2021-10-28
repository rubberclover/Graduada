using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    // Start is called before the first frame update
    LogicaCambioNivel nivel = new LogicaCambioNivel();
    public void PlayGame(){
      //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
      nivel.comenzar();
    }

    public void QuitGame(){
        Application.Quit();
    }
}
