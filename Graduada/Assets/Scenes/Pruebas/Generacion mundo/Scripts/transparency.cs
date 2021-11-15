using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transparency : MonoBehaviour
{
    private Renderer renderer;
    private GameObject[] building;
    private bool trans = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        building = GameObject.FindGameObjectsWithTag("edificio1");
        for( int i = 0; i < building.Length; i++){
            renderer= building[i].GetComponent<MeshRenderer>();
            renderer.enabled = false;
        }
    }
    void OnTriggerExit(Collider col)
    {
        building = GameObject.FindGameObjectsWithTag("edificio1");
        for( int i = 0; i < building.Length; i++){
            renderer= building[i].GetComponent<MeshRenderer>();
            renderer.enabled = true;
        }   
    }
}