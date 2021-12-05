using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class BotonVolverOpciones : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject currentSelected;
    MenuPrincipal principio;
    public GameObject MenuPrincipal,MenuOpciones;
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
            MenuOpciones.SetActive(false);
            MenuPrincipal.SetActive(true);
            principio = GameObject.FindGameObjectWithTag("MenuPrincipal").GetComponent<MenuPrincipal>();
            principio.ChargeButton();
        }
         } 
    }
}
