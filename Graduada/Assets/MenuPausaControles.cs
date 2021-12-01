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
        EventSystem.current.SetSelectedGameObject(botonVolver); 
        }
        }
            if(Input.GetKey(KeyCode.R) && GameIsInControles){
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
}
