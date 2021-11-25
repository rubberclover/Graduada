using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricPlayerMovement : MonoBehaviour
{   
    CharacterController characterController;
    public Vector3 respawnPosition;
    [SerializeField]
    public float speed = 12;
    [SerializeField]
    public float jumpSpeed = 16.0f;
    [SerializeField]
    public float gravity = 40.0f;

    private Vector3 moveDirection = Vector3.zero;
    private Vector3 forward, right;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            Vector3 rightMovement = right * speed * Time.deltaTime * Input.GetAxis("HorizontalStreet");
            Vector3 upMovement = forward * speed * Time.deltaTime * Input.GetAxis("VerticalStreet");
 

            moveDirection = Vector3.Normalize(rightMovement + upMovement);
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;

        characterController.Move(moveDirection * Time.deltaTime);
    }
    public void respawn(){
        gameObject.transform.position = respawnPosition;
    }

    void OnCollisionEnter(Collision otro){
        Debug.Log(otro.gameObject.name);
        Debug.Log(otro.gameObject.tag);
        Debug.Log("asdasd");
        if(otro.gameObject.tag == "Carretera1" || otro.gameObject.tag == "Carretera2" || otro.gameObject.tag == "Carretera3" || otro.gameObject.tag == "Carretera4"){
            Debug.Log("Cuidadooorl");
            respawn();
        }
    }
}





















