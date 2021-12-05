using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuPausaControles : MonoBehaviour
{
    // Start is called before the first frame update
    public bool GameIsInControles = false;
    public GameObject  MenuOpcionesUI,MenuControlesUI,botonVolver, cambita;

    MenuPausaOpciones misPausas;

    // Update is called once per frame
    void Update()
    {
        if(GameIsInControles){
        if(EventSystem.current.currentSelectedGameObject==null){
        StartCoroutine(Esperar());
        }
        }
            if(Input.GetKey(KeyCode.Return) && GameIsInControles && EventSystem.current.currentSelectedGameObject!=null){
            switch(EventSystem.current.currentSelectedGameObject.name){
                case "VolverControles":
                EventSystem.current.SetSelectedGameObject(null);
                GameIsInControles = false;
                MenuOpcionesUI.SetActive(true);
                MenuControlesUI.SetActive(false);
                misPausas=cambita.GetComponent<MenuPausaOpciones>();
                misPausas.GameIsInOptions = true;
                break;
                default :
                break;
            }
        }
    }

    IEnumerator Esperar(){
        yield return new WaitForSecondsRealtime(0.2f);
        EventSystem.current.SetSelectedGameObject(botonVolver); 
    }
}
