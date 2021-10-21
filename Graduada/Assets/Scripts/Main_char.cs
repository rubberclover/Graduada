using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_char : Basic_char
{

    // Start is called before the first frame update
    void Start()
    {
        vida = 100.0f;
        energia = 100.0f;
        
    }

    // Update is called once per frame
    void Update()
    {
         transform.Translate(new Vector3(Input.GetAxis("Horizontal") * 10*Time.deltaTime, 0.0f, Input.GetAxis("Vertical") * 10*Time.deltaTime));
    }
}
