using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaEnemigo : MonoBehaviour
{
    public int health = 4;
    AudioSource sonido;
    // Start is called before the first frame update
    void Start()
    {
        sonido = GameObject.Find("golpeAlSectario").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoseHealth(acciones_Street street)
    {
        print("AAAAAAAAA");
        sonido.Play();
        health--;
        //animacion?

        if (health == 0)
        {
            street.EnemyKO();
            Drop();
            //animacion muerte
            Destroy(gameObject);
        }
    }

    public void Drop(){
        print("Objeto Dropeado");
    }
}