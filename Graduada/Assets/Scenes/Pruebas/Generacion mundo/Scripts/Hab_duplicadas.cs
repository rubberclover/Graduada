using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hab_duplicadas : MonoBehaviour
{
    public GameObject[] verde;
    public GameObject[] rojo;
    private Templates templates;
    IsometricPlayerMovement mov;
    GameObject protagonista;
    acciones_Street aS;
    public GameObject Enemigos;
    bool heEstado;

    void Start(){
        heEstado = false;
        protagonista = GameObject.FindGameObjectWithTag("Player");
        aS = protagonista.GetComponent<acciones_Street>();
        templates = GameObject.FindGameObjectWithTag("ListasHabitaciones").GetComponent<Templates>();
    }
    void OnTriggerEnter(Collider otro){
        Debug.Log("he colisionao");
        if(otro.CompareTag("Colision")){
            Destroy(gameObject);
        }
        else if(otro.CompareTag("Player")){
            Debug.Log("Personaje esta aqui");
            mov = otro.GetComponent<IsometricPlayerMovement>();
            mov.respawnPosition = gameObject.transform.position;
            if(!heEstado){
                heEstado = true;
                Instantiate(Enemigos, mov.respawnPosition, Quaternion.identity, transform.parent);
                Enemigos.SetActive(true);
                Debug.Log("Enemigoooos");
            }
            Debug.Log(mov.respawnPosition);
        }
    }
    void Update(){
        if(aS.muertos){
            for(int i = 0; i< verde.Length; i++){
                verde[i].SetActive(true);
                rojo[i].SetActive(false);
            }
        }
        else{
            for(int i = 0; i< verde.Length; i++){
                rojo[i].SetActive(true);
                verde[i].SetActive(false);
            }
        }        
    }
}
