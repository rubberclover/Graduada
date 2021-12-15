using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class acciones_Piso : MonoBehaviour
{
    ChangeLevelLogic level = new ChangeLevelLogic();
    // Start is called before the first frame update
    void Start()
    {
        //if se han enviado objetos then mostrar cartel
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape)){
            Exit();
        }
    }
    void OnTriggerStay (Collider col)
    {
        if (Input.GetButton("Action"))
        {
            if(col.CompareTag("zonaSalida"))
            {
                level.goStreets();
            }
        }
    }

    void Exit(){
        level.goMainMenu();
    }

}
