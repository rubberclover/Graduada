using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class acciones_Street : MonoBehaviour
{

    //Player player
    //Array inventario
    ChangeLevelLogic level = new ChangeLevelLogic();
    //private GameObject inicial;
    public bool muertos, enemyHitbox;
    private Animator _animator;

    private GameObject enemy;
    private vidaEnemigo vidaEnemigo;
    void Start()
    {
        muertos = false;
        enemyHitbox = false;
        _animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("enemy").Length == 0){
            //print("no quedan enemigos");
            muertos = true;
        }else muertos = false;
        
        if(Input.GetButton("Uber")){
            returnHome();
        }
        if(Input.GetMouseButtonDown(0) && enemyHitbox){
            attack();
        }
    }

    void OnTriggerEnter(Collider col){
        if(col.CompareTag("enemyHitbox")){
            enemy = col.gameObject.transform.parent.gameObject;
            vidaEnemigo = enemy.GetComponent<vidaEnemigo>();
            print(vidaEnemigo);
            enemyHitbox = true;
        }
    }
    void OnTriggerExit(Collider col){
        if(col.CompareTag("enemyHitbox")){
            enemyHitbox = false;
        }
    }

    private void attack(){
        _animator.SetBool("attack", true);
        if(_animator.GetCurrentAnimatorStateInfo(0).IsName("attack")){
            Debug.Log("atacando");
        }
        else if(_animator.GetCurrentAnimatorStateInfo(0).IsName("parado")){
            Debug.Log("no ataco");
        }
        vidaEnemigo.LoseHealth();
        _animator.SetBool("attack", false);
    }

    private void returnHome(){
        //Iniciar animacion
        //Cargar inventario de player en el array del inventario
        //Eliminar la mitad del inventario de forma aleatoria
        // ¿Enviar el inventario a el inventario del piso ?
        level.start();

    }
}
