using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuPausaOpciones : MonoBehaviour
{
    public bool GameIsInOptions = false;
    public GameObject  MenuOpcionesUI,MenuControlesUI,MenuPausaUI,botonVolver,botonOpciones, cambita;

    MenuPausa misPausas;
    MenuPausaControles misControles;
    // Start is called before the first frame updat
    // Update is called once per frame
    void Update()
    {
        if(GameIsInOptions){
        if(EventSystem.current.currentSelectedGameObject==null){
            StartCoroutine(Esperar());
            }
        }
            if(Input.GetKey(KeyCode.Return) && GameIsInOptions && EventSystem.current.currentSelectedGameObject!=null){
            switch(EventSystem.current.currentSelectedGameObject.name){
                case "VolverOpciones":
                EventSystem.current.SetSelectedGameObject(null);
                GameIsInOptions = false;
                MenuPausaUI.SetActive(true);
                MenuOpcionesUI.SetActive(false);
                misPausas=cambita.GetComponent<MenuPausa>();
                misPausas.GameIsInMenuPause = true;
                
                break;
                case "OpcionesMain":
                EventSystem.current.SetSelectedGameObject(null);
                GameIsInOptions = false;
                MenuControlesUI.SetActive(true);
                MenuOpcionesUI.SetActive(false);
                misControles=cambita.GetComponent<MenuPausaControles>();
                misControles.GameIsInControles = true;
                break;
                default :
                break;
            }
        }    
    }
    IEnumerator Esperar(){
        yield return new WaitForSecondsRealtime(0.2f);
        EventSystem.current.SetSelectedGameObject(botonOpciones); 
  }
}
