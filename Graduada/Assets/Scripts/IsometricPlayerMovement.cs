using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class IsometricPlayerMovement : MonoBehaviour {
 
    [SerializeField]
    float moveSpeed = 12f;
 
    Vector3 forward, right;

    bool jump = false;
    
    [SerializeField]
    float jumpHeight = 8f, jumpSpeed = 15f;
    Rigidbody rigidbody;
 
    void Start ()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        rigidbody = GetComponent<Rigidbody>();
    }
 
 
    void Update ()
    {
        if (Input.GetButtonDown("Jump") && !jump){
            StartCoroutine(Jump());
        }else Move();
    }
 
    void Move()
    {
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalStreet");
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalStreet");
 
        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
 
        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;
    }

    IEnumerator Jump(){
        float originalHeight = transform.position.y;
        float maxHeight = originalHeight + jumpHeight;
        rigidbody.useGravity = false;

        jump = true;
        yield return null;


        while(transform.position.y < maxHeight)
        {
            transform.position += transform.up * Time.deltaTime * jumpSpeed; 
            yield return null;
        }

        //rigidbody.useGravity = true;

        while(transform.position.y > originalHeight){
            transform.position -= transform.up * Time.deltaTime * jumpSpeed; //si la gravedad está activada, desactivar
            yield return null;
        }

        rigidbody.useGravity = true;
        jump = false;

        yield return null;
    }
}

     
