using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ProtagonistaVida : MonoBehaviour
{
    public GameObject proyectil;

    public GameObject MenuMuerteUI, cambita;
    public Image[] corazones;
    public int health;
    GameObject player;
    AudioSource sonido;
    bool semaforo = true;
    MenuMuerte muero;
    bool pierdo;

    //100 health 


    void Start()
    {
        sonido = GameObject.Find("golpeSectario").GetComponent<AudioSource>();
        pierdo = true;
    }

    private IEnumerator invencibilidad(){
        yield return new WaitForSeconds(1);
        pierdo = true;
    }
    public void LoseHealth()
    {
        if(pierdo){
            pierdo = false;
            health--;
            corazones[health].enabled = false;
        }

        if (health == 0)
        {
            MenuMuerteUI.SetActive(true);
            Time.timeScale = 0f;
            EventSystem.current.SetSelectedGameObject(null);
            muero = cambita.GetComponent<MenuMuerte>();
            muero.GameDeath = true;
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
        if(!pierdo) StartCoroutine(invencibilidad());


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
            sonido.Play();
            Debug.Log("choca");
            LoseHealth();
            Destroy(collision.gameObject);
        }
        
    }
}