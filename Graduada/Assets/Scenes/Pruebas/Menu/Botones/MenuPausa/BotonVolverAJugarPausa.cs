using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 using UnityEngine.Events;
 using UnityEngine.EventSystems;

public class BotonVolverAJugarPausa : MonoBehaviour
{
     MenuPausa Pause = new MenuPausa();
     GameObject currentSelected;
     
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M)){
            Debug.Log(currentSelected.name);
        }
       currentSelected = EventSystem.current.currentSelectedGameObject;
 
         if(currentSelected.name == "VolverAJugar")
         {
            if(Input.GetKeyDown(KeyCode.Q)){
                Debug.Log("Gay");
                Pausar();
          }
         } 
    }

    private void Pausar(){
        Pause.Resume();
    }
}
