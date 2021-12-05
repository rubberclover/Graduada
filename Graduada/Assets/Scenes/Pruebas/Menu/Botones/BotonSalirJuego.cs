using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 using UnityEngine.Events;
 using UnityEngine.EventSystems;
public class BotonSalirJuego : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject currentSelected;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentSelected = EventSystem.current.currentSelectedGameObject;
 
         if(currentSelected.name == "BotonSalir")
         {
            if(Input.GetKeyDown(KeyCode.Return) || Input.GetKey(KeyCode.Escape)){
            Application.Quit();
        }
         } 
    }
}
