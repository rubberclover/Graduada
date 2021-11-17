using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevelLogic
{
    public int mainMenu = 0;
    public int loadMenu = 1;
    public int settingsMenu = 2;
    public int home = 3;
    public int street = 4;

    public void start(){
        //Cargar partida reciente
        SceneManager.LoadScene(home);
    }
    public void goLoadMenu(){
        SceneManager.LoadScene(loadMenu);
    }
    public void goSettings(){
        SceneManager.LoadScene(settingsMenu);
    }

    public void goStreets(){
        //generador ?
        SceneManager.LoadScene(street);
    }

    public void goMainMenu(){
        SceneManager.LoadScene(mainMenu);
    }

}