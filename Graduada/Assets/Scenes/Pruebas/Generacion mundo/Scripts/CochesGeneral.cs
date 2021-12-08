using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CochesGeneral : MonoBehaviour
{
    public GameObject Coche;
    public  Vector3 coord;

    acciones_Street script;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnTriggerEnter(Collider otro){
        // 160,20,120
        if(otro.CompareTag("Player")){
            script = otro.GetComponent<acciones_Street>();
            bool muertos = script.muertos;
            //bool muertos = true;
            if(gameObject.name == "Carretera1"){
                Coche.tag = "Carretera1";
                Instantiate(Coche, Vector3.zero, Quaternion.identity, gameObject.transform.parent);
                
            }
            if(gameObject.name == "Paso1" && muertos == false){
                Coche.tag = "Paso1";
                Instantiate(Coche, Vector3.zero, Quaternion.identity, gameObject.transform.parent);
            }
            else if(gameObject.name == "Carretera2" || (gameObject.name == "Paso2" && muertos == false)){
                Coche.tag = "Carretera2";
                Instantiate(Coche, Vector3.zero, Quaternion.identity, gameObject.transform.parent);
                
            }
            else if(gameObject.name == "Carretera3" || (gameObject.name == "Paso3" && muertos == false)){
                Coche.tag = "Carretera3";
                Instantiate(Coche, Vector3.zero,Quaternion.Euler(0.0f, -90.0f, 0.0f), gameObject.transform.parent);
                
            }
            else if(gameObject.name == "Carretera4" || (gameObject.name == "Paso4" && muertos == false)){
                Coche.tag = "Carretera4";
                Instantiate(Coche, Vector3.zero, Quaternion.Euler(0.0f, -90.0f, 0.0f), gameObject.transform.parent);
                
            }
        }
    }
}
