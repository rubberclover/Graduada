using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CochesGeneral : MonoBehaviour
{
    public GameObject Coche;
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
            if(gameObject.name == "Carretera1"){
                Debug.Log(gameObject.transform.parent.parent);
                Coche.tag = "Carretera1";
                Instantiate(Coche, new Vector3(-40,5,-30), Quaternion.identity, gameObject.transform.parent.parent);
            }
            else if(gameObject.name == "Carretera2"){
                Debug.Log(transform.parent.parent);
                Coche.tag = "Carretera2";
                Instantiate(Coche, new Vector3(-40,5,30), Quaternion.identity, gameObject.transform.parent.parent);
            }
            else if(gameObject.name == "Carretera3"){
                Debug.Log(transform.parent.parent);
                Coche.tag = "Carretera3";
                Instantiate(Coche, new Vector3(30,5,-40), Quaternion.identity, gameObject.transform.parent.parent);
            }
            else if(gameObject.name == "Carretera4"){
                Debug.Log(transform.parent.parent);
                Coche.tag = "Carretera4";
                Instantiate(Coche, new Vector3(-30,5,-40), Quaternion.identity, gameObject.transform.parent.parent);
            }
        }
    }
}
