using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proyectil : MonoBehaviour
{
    public ProtagonistaVida vida;
    public bool dañoRecibido;

    AudioSource sonido;
    void Start()
    {
        sonido = GameObject.Find("JugadorGolpeado").GetComponent<AudioSource>();
        vida = new ProtagonistaVida();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.name == "Protagonista"){
            ImpactoGrande();
            Invoke("Despawn", 2f);
        }else{
            Invoke("Despawn", 2f);
        }
    }

    void Despawn(){
        Destroy(this.gameObject);
    }

    void ImpactoLeve(){}
    void ImpactoGrande(){
        sonido.Play();
        dañoRecibido = true;
        vida.LoseHealth();
    }
}
