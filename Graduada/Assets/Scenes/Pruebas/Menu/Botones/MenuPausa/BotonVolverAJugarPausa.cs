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
       currentSelected = EventSystem.current.currentSelectedGameObject;
 
         if(currentSelected.name == "BotonVolverAJugarPausa")
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
