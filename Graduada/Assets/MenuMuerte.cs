using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class MenuMuerte : MonoBehaviour
{
    public bool GameDeath = false;
    LogicaCambioNivel cambiar = new LogicaCambioNivel();

     public GameObject MenuMuerteUI,botonVolverCasa,botonVolverMenu, cambita;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameDeath){
        if(EventSystem.current.currentSelectedGameObject==null){
          StartCoroutine(Esperar());
       }
     }

     if(Input.GetKey(KeyCode.Return) &&  GameDeath && EventSystem.current.currentSelectedGameObject!=null){
       
       switch(EventSystem.current.currentSelectedGameObject.name){
         case "VolverMenu":
         LoadMenu();
         break;
         case "VolverCasa":
         LoadCasa();
         break;
         default :
         break;
       }
      }
    }

    IEnumerator Esperar(){
        yield return new WaitForSecondsRealtime(0.2f);
        EventSystem.current.SetSelectedGameObject(botonVolverMenu); 
  }
  public void LoadMenu(){
       EventSystem.current.SetSelectedGameObject(null);
       cambiar.cargarMenuPrincipal();
       Time.timeScale = 1f;
    }

    public void LoadCasa(){
       EventSystem.current.SetSelectedGameObject(null);
       cambiar.comenzar();
       Time.timeScale = 1f;
    }
}
