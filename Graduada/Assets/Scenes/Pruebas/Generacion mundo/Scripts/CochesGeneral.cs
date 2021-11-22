using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CochesGeneral : MonoBehaviour
{
    public GameObject Coche;
    public  Vector3 coord;
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
                Coche.tag = "Carretera1";
                Instantiate(Coche, Vector3.zero, Quaternion.identity, gameObject.transform.parent.parent);
                
            }
            else if(gameObject.name == "Carretera2"){
                Coche.tag = "Carretera2";
                Instantiate(Coche, Vector3.zero, Quaternion.identity, gameObject.transform.parent.parent);
                
            }
            else if(gameObject.name == "Carretera3"){
                Coche.tag = "Carretera3";
                Instantiate(Coche, Vector3.zero, Quaternion.identity, gameObject.transform.parent.parent);
                
            }
            else if(gameObject.name == "Carretera4"){
                Coche.tag = "Carretera4";
                Instantiate(Coche, Vector3.zero, Quaternion.identity, gameObject.transform.parent.parent);
                
            }
        }
    }
}
