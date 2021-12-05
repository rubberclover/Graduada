using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 using UnityEngine.Events;
 using UnityEngine.EventSystems;
public class BotonOpciones : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject currentSelected;
    public GameObject MenuPrincipal,MenuOpciones;

    MenuOpciones opciones;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentSelected = EventSystem.current.currentSelectedGameObject;
 
         if(currentSelected.name == "BotonOpciones")
         {
            if(Input.GetKeyDown(KeyCode.Return)){
            MenuPrincipal.SetActive(false);
            MenuOpciones.SetActive(true);
            opciones = GameObject.FindGameObjectWithTag("MenuOpcionesPrincipal").GetComponent<MenuOpciones>();
            opciones.ChargeButton();
        }
         } 
    }
}
