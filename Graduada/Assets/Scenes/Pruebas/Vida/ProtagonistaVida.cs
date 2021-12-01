using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProtagonistaVida : MonoBehaviour
{
    public GameObject proyectil;
    public Image[] corazones;
    public int health;
    GameObject player;

    //100 health 


    void start()
    {
     
    }

    public void LoseHealth()
    {
        health--;
        corazones[health].enabled = false;

        if (health == 0)
        {
            Debug.Log("You lose");
        }
    }

    public void GainHealth()
    {
        if (corazones.Length > health)
        { //No puedes darte más vida de la máxima
            corazones[health].enabled = true;
            health++;
        }
    }
    private void Update()
    {



        if (Input.GetKeyDown(KeyCode.M))
        {
            LoseHealth();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            GainHealth();
        }
    }

    void OnCollisionEnter(UnityEngine.Collision collision)
    {

        if (collision.gameObject.name == "Proyectil(Clone)"  )
        {
            Debug.Log("choca");
            LoseHealth();
            Destroy(collision.gameObject);
        }
    }
}