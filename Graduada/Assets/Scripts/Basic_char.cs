using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_char : MonoBehaviour
{
    enum State{Iddle, Walk, Run, Dead};
    public float vida; //Sin valores porque posiblemente sea diferente para cada enemigo
    public float energia;
    public Rigidbody rb;
    Vector3 velocidad, posInicial, acc;

    public void init(){
        rb = GetComponent<Rigidbody>();
        posInicial = transform.position;
        velocidad = new Vector3(1.0f, 1.0f, 1.0f);
        acc = new Vector3(0.0f, 0.0f, 0.0f);
        State charState = State.Iddle;
    }

    public void reset()
    {
        transform.position = posInicial;
        detenerMovimiento();
        State charState = State.Iddle;

    }

    public void detenerMovimiento()
    {
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        acc = Vector3.zero;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
