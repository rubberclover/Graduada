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

    public void LoseHealth()
    {
        print("AAAAAAAAA");
        sonido.Play();
        health--;
        //animacion?

        if (health == 0)
        {
            Drop();
            //animacion muerte
            Destroy(this.gameObject);
        }
    }

    public void Drop(){
        print("Objeto Dropeado");
    }
}