using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCoche : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 coord1;
    private Vector3 coord2;
    private Vector3 mov;
    void Start()
    {
        if(gameObject.transform.parent.name == "ULR-Inicial"){
            coord1 = new Vector3(280, 20, 120);
            coord2 = new Vector3(240, 20, 160);
        }
        else{
            coord1 = new Vector3(160,20,120);
            coord2 = new Vector3(120,20,160);
        }

        if (gameObject.tag == "Carretera1"){
            gameObject.transform.localPosition = new Vector3(-coord1.x,20,-coord1.z);
            mov = new Vector3(130 * Time.deltaTime,0,0);
        }
        else if (gameObject.tag == "Carretera2"){
            gameObject.transform.localPosition = new Vector3(-coord1.x,20,coord1.z);
            mov = new Vector3(130 * Time.deltaTime,0,0);
        }
        else if (gameObject.tag == "Carretera3"){
            gameObject.transform.localPosition = new Vector3(coord2.x,20,-coord2.z);
            mov = new Vector3(0,0, 130 * Time.deltaTime);
        }
        else if (gameObject.tag == "Carretera4"){
            gameObject.transform.localPosition = new Vector3(-coord2.x,20,-coord2.z);
            mov = new Vector3(0,0,130 * Time.deltaTime);

        }
        Invoke("Despawn", 1f);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(mov);
    }
    void Despawn(){
        Destroy(gameObject);
    }
}
