using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hab_duplicadas : MonoBehaviour
{
    IsometricPlayerMovement mov;
    void OnTriggerEnter(Collider otro){
        if(otro.CompareTag("Colision")){
            Destroy(gameObject);
        }
        else if(otro.CompareTag("Player")){
            Debug.Log("Personaje esta aqui");
            mov = otro.GetComponent<IsometricPlayerMovement>();
            mov.respawnPosition = gameObject.transform.position;
            Debug.Log(mov.respawnPosition);
        }
    }
}
