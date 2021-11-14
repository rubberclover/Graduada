using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int direccion;
    // Puertas que tiene que tener la habitaci�n que aparecer� en ese punto
    // 1 = Puerta hacia abajo
    // 2 = Puerta hacia arriba
    // 3 = Puerta hacia la izquierda
    // 4 = Puerta hacia la derecha
    private Templates templates;
    public int rand;
    private bool spawned = false;
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("ListasHabitaciones").GetComponent<Templates>();
        Invoke("Spawn", 0.1f);
    }
    void Spawn()
    {
        if (spawned==false){
            // Generamos las habitaciones
            if (direccion == 1)
            {
                // Añadir contador para tamaño máximo de mapa
                rand = Random.Range(0, templates.BottomRooms.Length);
                Instantiate(templates.BottomRooms[rand], transform.position, templates.BottomRooms[rand].transform.rotation);
            }
            else if (direccion == 2)
            {
                rand = Random.Range(0, templates.TopRooms.Length);
                Instantiate(templates.TopRooms[rand], transform.position, templates.TopRooms[rand].transform.rotation);
            }
            else if (direccion == 3)
            {
                rand = Random.Range(0, templates.LeftRooms.Length);
                Instantiate(templates.LeftRooms[rand], transform.position, templates.LeftRooms[rand].transform.rotation);
            }
            else
            {
                rand = Random.Range(0, templates.RightRooms.Length);
                Instantiate(templates.RightRooms[rand], transform.position, templates.RightRooms[rand].transform.rotation);
            }
            spawned = true;
     

        }
        
    }
    void OnTriggerEnter(Collider otro){
        if(otro.CompareTag("SpawnPoint") && otro.GetComponent<Spawner>().spawned == true){
            Destroy(gameObject);
        }
        if(otro.CompareTag("Colision")){
            Destroy(gameObject);
        }
    }
}

