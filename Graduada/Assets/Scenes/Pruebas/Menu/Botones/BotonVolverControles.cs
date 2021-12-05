using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BotonVolverControles : MonoBehaviour
{
    // Start is called before the first frame updateGameObject currentSelected;
    GameObject currentSelected;
    MenuOpciones op;
    public GameObject MenuControles,MenuOpciones;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentSelected = EventSystem.current.currentSelectedGameObject;
 
         if(currentSelected.name == "BotonVolver")
         {
            if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Escape)){
            MenuOpciones.SetActive(true);
            MenuControles.SetActive(false);
            op = GameObject.FindGameObjectWithTag("MenuOpcionesPrincipal").GetComponent<MenuOpciones>();
            op.ChargeButton();
        }
         } 
    }
}
