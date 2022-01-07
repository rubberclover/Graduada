using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class vidaEnemigo : MonoBehaviour
{
    //sistema dropeo
    public GameObject dropSystem;
    private int health = 2;
    AudioSource sonido;
    // Start is called before the first frame update
    Animator _animator;
    public bool muerto = false;
    void Start()
    {
        dropSystem = GameObject.FindGameObjectWithTag("inventario");
        sonido = GameObject.Find("golpeAlSectario").GetComponent<AudioSource>();
        _animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_animator.GetCurrentAnimatorStateInfo(0).IsName("Dano")){
            StartCoroutine(rutina());
        }
    }

    public void LoseHealth(acciones_Street street)
    {
        print("AAAAAAAAA");
        sonido.Play();
        health--;
        //animacion?

        if (health == 0)
        {
            _animator.SetBool("Muerto", true);
            muerto = true;
            gameObject.GetComponent<NavMeshAgent>().speed = 0;
            street.EnemyKO();
            Drop();
            StartCoroutine(muerte());
            //animacion muerte
            //Destroy(gameObject);
        }
        _animator.SetBool("Hit", true);
    }

    private IEnumerator muerte(){
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
    private IEnumerator rutina(){
        yield return new WaitForSeconds(0.2f);
        _animator.SetBool("Hit", false);

    }

    public void Drop(){
        dropSystem.GetComponent<Drops>().Drop(transform.position);
    }
}