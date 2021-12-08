using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzarProyectil : MonoBehaviour
{
    public GameObject proyectil;
    public float launchVelocity = 900f;
    public int shoot = 1;
    public float shootingDistance = 10f;

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
            StartCoroutine(ExecuteAfterTime(1,ball));

        }

        
      
    }

    IEnumerator ExecuteAfterTime(float time, GameObject ball)
    {
        yield return new WaitForSeconds(time);
        Destroy(ball);
        shoot = 1;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, shootingDistance);

    }
}

