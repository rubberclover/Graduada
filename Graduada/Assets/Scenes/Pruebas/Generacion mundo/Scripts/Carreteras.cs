using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carreteras : MonoBehaviour
{
    void Start(){
        //Debug.Log("gameObject.tag");
        //Debug.Log(gameObject.tag);
    }
    void OnTriggerEnter(Collider otro){
        Debug.Log("1." + gameObject.name);
        Debug.Log("2." + otro.name);
        if(gameObject.name == "Carretera1" && otro.name == "Carretera2"){
            Debug.Log(gameObject.transform.parent.parent.name + "Chocamos arriba");
            Destroy(gameObject);
        }
        else if(gameObject.name == "Carretera3" && otro.name == "Carretera4"){
            Debug.Log(gameObject.transform.parent.parent.name + "Chocamos lateral");
            Destroy(gameObject);
        }
    }
}
