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
    bool ataque;

    void Start()
    {
        muertos = false;
        enemyHitbox = false;
        _animator = gameObject.GetComponent<Animator>();
        ataque = true;
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
        if(Input.GetMouseButtonDown(0) && ataque){
            _animator.SetBool("attack", true);
            ataque = false;
            if(enemyHitbox) attack();
        }

        if(_animator.GetCurrentAnimatorStateInfo(0).IsName("atacando")){
            StartCoroutine(rutina());
        }

    }

    void OnTriggerStay(Collider col){
        if(col.CompareTag("enemyHitbox")){
            Debug.Log("Angulo: " + Vector3.Angle(transform.forward, col.transform.position - transform.position));
            if(Vector3.Angle(transform.forward, col.transform.position - transform.position) < 90){
                enemy = col.gameObject.transform.parent.gameObject;
                vidaEnemigo = enemy.GetComponent<vidaEnemigo>();
                enemyHitbox = true;
            }
        }
    }
    void OnTriggerExit(Collider col){
        if(col.CompareTag("enemyHitbox")){
            enemyHitbox = false;
        }
    }

    private void attack(){
        vidaEnemigo.LoseHealth(this);
    }

    public void EnemyKO(){
       print("MUERTISIMO CHAVAL");
       enemyHitbox = false;
    }

    private IEnumerator rutina(){
        yield return new WaitForSeconds(0.2f);
        ataque = true;
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
