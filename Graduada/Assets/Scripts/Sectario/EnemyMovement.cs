using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public float lookRadius = 20f;
    public float life = 100.00f;

    Transform target;
    NavMeshAgent agent;
    GameObject jugador;
    private Animator _animator;
   

    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        target = jugador.transform;
        agent = GetComponent<NavMeshAgent>();
        _animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        //_animator.SetBool("moving", false);
        if (distance <= lookRadius)
        {
            _animator.SetBool("Detectado", true);
            Debug.Log("Voy a correr");
            if(_animator.GetCurrentAnimatorStateInfo(0).IsName("Correr")){
                Debug.Log("Corro");
            }
            agent.SetDestination(target.position);
        }

       
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);

    }

}
