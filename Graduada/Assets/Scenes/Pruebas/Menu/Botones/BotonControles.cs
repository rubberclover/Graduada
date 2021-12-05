using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 using UnityEngine.Events;
 using UnityEngine.EventSystems;

public class BotonControles : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject currentSelected;
    public GameObject MenuControles,MenuOpciones;

    MenuControles Control;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentSelected = EventSystem.current.currentSelectedGameObject;
 
         if(currentSelected.name == "BotonControles")
         {
            if(Input.GetKeyDown(KeyCode.Return)){
            MenuOpciones.SetActive(false);
            MenuControles.SetActive(true);
            Control= GameObject.FindGameObjectWithTag("MenuControlesPrincipal").GetComponent<MenuControles>();
            Control.ChargeButton();
        }
         } 
    }
}

