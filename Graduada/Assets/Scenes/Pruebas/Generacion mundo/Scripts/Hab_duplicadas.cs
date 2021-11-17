using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hab_duplicadas : MonoBehaviour
{
    void onTriggerEnter(Collider otro){
        if(otro.CompareTag("Colision")){
            Destroy(gameObject);
        }
    }
}
