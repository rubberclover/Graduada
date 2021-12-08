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
    ProtagonistaVida vida;
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 forward, right, point, moveVector;
    private Animator _animator;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        _animator = gameObject.GetComponent<Animator>();
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
                _animator.SetBool("jumping", true);
                moveDirection.y = jumpSpeed;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        _animator.SetBool("jumping", false);

        _animator.SetFloat("speed", 0.2f);
        characterController.Move(moveDirection * Time.deltaTime);
        _animator.SetFloat("speed", 0f);
    }
    public void respawn(){
        vida = gameObject.GetComponent<ProtagonistaVida>();
        point = new Vector3(respawnPosition.x, respawnPosition.y + 5, respawnPosition.z);
        moveVector = transform.TransformDirection(point - transform.position);
        characterController.Move(moveVector);
        vida.LoseHealth();
    }

   
}





















