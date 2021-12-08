using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform PlayerTransform;
    private Vector3 _cameraOffset; 

    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;


    
    void Start()
    {
        //transform.position = new Vector3(-2f, 10f, 12.8f);
        _cameraOffset = transform.position - PlayerTransform.position;
    }

    void Update()
    {
        Vector3 newPos = PlayerTransform.position + _cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);
    }
}
