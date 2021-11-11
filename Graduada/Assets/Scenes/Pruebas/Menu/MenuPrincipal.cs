using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    // Start is called before the first frame update
    ChangeLevelLogic level = new ChangeLevelLogic();
    public void PlayGame(){
      level.start();
    }

    public void QuitGame(){
        Application.Quit();
    }
}
