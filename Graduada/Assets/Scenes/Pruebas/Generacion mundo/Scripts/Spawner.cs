using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int direccion;
    // Puertas que tiene que tener la habitacion que aparecera en ese punto
    // 1 = Puerta hacia abajo (++)
    // 2 = Puerta hacia arriba (--)
    // 3 = Puerta hacia la izquierda (++)
    // 4 = Puerta hacia la derecha (--)
    private Templates templates;
    private int rand;
    private int maxHab;
    private int tamano;
    private bool spawned = false;
    //public bool bar;
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("ListasHabitaciones").GetComponent<Templates>();
        maxHab = templates.maxHab;
        //bar = templates.bar;
        Invoke("Spawn", 0.5f);
    }
    void Spawn()
    {
        if (spawned==false){
            // Generamos habitaciones arriba (necesita puerta abajo)
            if (direccion == 1)
            {
                tamano = templates.BottomRooms.Length;
                if(Templates.numHab == maxHab){
                    //Debug.Log("Arriba max");
                    Destroy(gameObject);
                    if(Templates.bar){
                        Instantiate(templates.BottomRooms[tamano-2], transform.position, templates.BottomRooms[tamano-2].transform.rotation);
                    }else{
                        StartCoroutine(esperar(Random.Range(1,5)));
                        if(Templates.bar == false){
                            Debug.Log("Spawneo bar" + Templates.bar);
                            Templates.bar = true;
                            Debug.Log("Spawneo bar" + Templates.bar);
                            Instantiate(templates.BottomRooms[tamano-1], transform.position, templates.BottomRooms[tamano-1].transform.rotation);
                        }
                    }
                }
                else{
                    //Debug.Log("Arriba");
                    rand = Random.Range(0, tamano);
                    if(rand == tamano -1 && Templates.bar == false){
                        StartCoroutine(esperar(Random.Range(1,5)));
                        if(Templates.bar == false){
                            Debug.Log("Spawneo bar" + Templates.bar);
                            Templates.bar = true;
                            Debug.Log("Spawneo bar" + Templates.bar);
                        }
                    } 
                    else if(rand == tamano -1 && Templates.bar == true) rand = rand - 1;
                    Destroy(gameObject);
                    Instantiate(templates.BottomRooms[rand], transform.position, templates.BottomRooms[rand].transform.rotation);
                    Templates.numHab+=1;
                }
            }
            else if (direccion == 2)
            {
                tamano = templates.TopRooms.Length;
                if(Templates.numHab == maxHab){
                    //Debug.Log("Abajo max");
                    Destroy(gameObject);
                    Instantiate(templates.TopRooms[tamano -1], transform.position, templates.TopRooms[tamano -1].transform.rotation);
                }else{
                    //Debug.Log("Abajo");
                    rand = Random.Range(0,tamano);
                    Destroy(gameObject);
                    Instantiate(templates.TopRooms[rand], transform.position, templates.TopRooms[rand].transform.rotation);
                    Templates.numHab+=1;
                }
            }
            else if (direccion == 3)
            {
                tamano = templates.LeftRooms.Length;
                if(Templates.numHab == maxHab){
                    //Debug.Log("Der max");
                    Destroy(gameObject);
                    Instantiate(templates.LeftRooms[tamano-1], transform.position, templates.LeftRooms[tamano-1].transform.rotation);
                }else{
                    //Debug.Log("Derecha");
                    rand = Random.Range(0, tamano);
                    Destroy(gameObject);
                    Instantiate(templates.LeftRooms[rand], transform.position, templates.LeftRooms[rand].transform.rotation);
                    Templates.numHab+=1;
                }
            }
            else
            {
                tamano = templates.RightRooms.Length;
                if(Templates.numHab == maxHab){
                    //Debug.Log("Izq max");
                    Destroy(gameObject);
                    Instantiate(templates.RightRooms[tamano-1], transform.position, templates.RightRooms[tamano-1].transform.rotation);
                }else{
                    //Debug.Log("Izquierda");
                    rand = Random.Range(0, tamano);
                    Destroy(gameObject);
                    Instantiate(templates.RightRooms[rand], transform.position, templates.RightRooms[rand].transform.rotation);
                    Templates.numHab+=1;
                }
            }
            spawned = true;
     

        }
        
    }
    void OnTriggerEnter(Collider otro){
        if(otro.CompareTag("Colision")){
            Destroy(transform.parent.gameObject);
        }
    }
    private IEnumerator esperar(int segundos){
        yield return new WaitForSeconds(segundos/10);
    }
}

