using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCoche : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 coord1;
    private Vector3 coord2;
    private Vector3 mov;
    private bool isColliding;
    IsometricPlayerMovement scr;
    void Start()
    {
        if(gameObject.transform.parent.name == "ULR-Inicial" && gameObject.tag != "Paso1"){
            coord1 = new Vector3(280, 20, 120);
            coord2 = new Vector3(240, 20, 160);
        }else{
            coord1 = new Vector3(160,20,120);
            coord2 = new Vector3(120,20,160);
        }

        if (gameObject.tag == "Carretera1"){
            gameObject.transform.localPosition = new Vector3(-coord1.x,10,-coord1.z);
            mov = new Vector3(130 * Time.deltaTime,0,0);
        }
        else if(gameObject.tag == "Paso1"){
            gameObject.transform.localPosition = new Vector3(-coord1.x,10,-coord1.z);
            mov = new Vector3(130 * Time.deltaTime,0,0);
        }
        else if (gameObject.tag == "Carretera2"){
            gameObject.transform.localPosition = new Vector3(-coord1.x,10,coord1.z);
            mov = new Vector3(130 * Time.deltaTime,0,0);
        }
        else if (gameObject.tag == "Carretera3"){
            gameObject.transform.localPosition = new Vector3(coord2.x,10,-coord2.z);
            mov = new Vector3(0,0, 130 * Time.deltaTime);
        }
        else if (gameObject.tag == "Carretera4"){
            gameObject.transform.localPosition = new Vector3(-coord2.x,10,-coord2.z);
            mov = new Vector3(0,0,130 * Time.deltaTime);

        }
        Invoke("Despawn", 1f);
        
    }
    void Update(){
        if(isColliding) StartCoroutine(rutinaAtropellos());
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(mov, Space.World);
    }
    void Despawn(){
        Destroy(gameObject);
    }
    private IEnumerator rutinaAtropellos(){
        yield return new WaitForSeconds(1);
        isColliding = false;
    }
    void OnTriggerEnter(Collider otro){
        if(otro.gameObject.tag == "Player"){
            if(isColliding) return;
            isColliding = true;
            scr = otro.gameObject.GetComponent<IsometricPlayerMovement>();
            Debug.Log("Atropellao");
            scr.respawn();
        }
    }
}
