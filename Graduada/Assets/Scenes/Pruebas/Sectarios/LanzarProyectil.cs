using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzarProyectil : MonoBehaviour
{
    public GameObject proyectil;
    public float launchVelocity = 700f;
    public int shoot = 1;
    public float shootingDistance = 5f;

    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (shoot == 1 && distance <= shootingDistance)
        {
            shoot = 0;
            GameObject ball = Instantiate(proyectil, transform.position,
                                                          transform.rotation);
            ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3
                                                 (0, 0, launchVelocity));
            StartCoroutine(ExecuteAfterTime(2));

        }

        
      
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        shoot = 1;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, shootingDistance);

    }
}

