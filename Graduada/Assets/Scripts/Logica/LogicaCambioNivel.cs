using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicaCambioNivel : MonoBehaviour
{
    public int menuPrincipal = 0;
    public int menuCargarPartida = 1;
    public int menuOpciones = 2;
    public int piso = 3;
    public int calle = 4;
    public int menuPausa = 5;

    public void comenzar(){
        //Cargar partida reciente
        SceneManager.LoadScene(piso);
    }
    public void cargarPartida(){
        SceneManager.LoadScene(menuCargarPartida);
    }
    public void opciones(){
        SceneManager.LoadScene(menuOpciones);
    }

    public void salirCalle(){
        //generador ?
        SceneManager.LoadScene(calle);
    }
     public void cargarMenuPrincipal(){
       SceneManager.LoadScene(menuPrincipal);
    }

}