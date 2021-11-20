using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coches : MonoBehaviour
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
        if(otro.CompareTag("Player")){
            if(gameObject.name == "Carretera1"){
                Instantiate(Coche, new Vector3(-70,5,-30), Quaternion.identity, transform.parent.parent);
            }
            if(gameObject.name == "Carretera2"){
                Instantiate(Coche, new Vector3(-70,5,30), Quaternion.identity, transform.parent.parent);
            }
            if(gameObject.name == "Carretera3"){
                Instantiate(Coche, new Vector3(60,5,-40), Quaternion.identity, transform.parent.parent);
            }
            if(gameObject.name == "Carretera4"){
                Instantiate(Coche, new Vector3(-60,5,-40), Quaternion.identity, transform.parent.parent);
            }
        }
    }
}
