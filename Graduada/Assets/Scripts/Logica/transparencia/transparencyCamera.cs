using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transparencyCamera : MonoBehaviour
{
    [SerializeField] private List<transparencyObject> objectsToQuit;
    [SerializeField] private List<transparencyObject> objectsAlreadyT;
    [SerializeField] private Transform player;
    private Transform camera;


    private void Awake()
    {
        objectsToQuit = new List<transparencyObject>();
        objectsAlreadyT = new List<transparencyObject>();

        camera = this.gameObject.transform;
    }

    void Update()
    {
        getObjectsToT();

        MakeObjectsSolid();
        MakeObjectsTransparent();
    }

    private void getObjectsToT()
    {
        objectsToQuit.Clear();

        float cameraPlayerDistance = Vector3.Magnitude(camera.position - player.position);
        
        Ray ray1_Forward = new Ray(camera.position, player.position - camera.position);
        Ray ray1_Backward = new Ray(player.position, camera.position - player.position);

        var hits1_Forward = Physics.RaycastAll(ray1_Forward, cameraPlayerDistance);
        var hits1_Backward = Physics.RaycastAll(ray1_Backward, cameraPlayerDistance);

        foreach (var hit in hits1_Forward){
            if(hit.collider.gameObject.name == "edificio.001"){
                transparencyObject tObject = hit.collider.gameObject.GetComponentInParent(typeof(transparencyObject)) as transparencyObject;
                if(!objectsToQuit.Contains(tObject)){
                    objectsToQuit.Add(tObject);
                }
            }

            if(hit.collider.gameObject.name == "edificio"){
                transparencyObject tObject = hit.collider.gameObject.GetComponentInParent(typeof(transparencyObject)) as transparencyObject;
                if(!objectsToQuit.Contains(tObject)){
                    objectsToQuit.Add(tObject);
                }
            }
        }
        foreach (var hit in hits1_Backward){
            if(hit.collider.gameObject.name == "edificio.001"){
                transparencyObject tObject = hit.collider.gameObject.GetComponentInParent(typeof(transparencyObject)) as transparencyObject;
                if(!objectsToQuit.Contains(tObject)){
                    objectsToQuit.Add(tObject);
                }
            }

            if(hit.collider.gameObject.name == "edificio"){
                transparencyObject tObject = hit.collider.gameObject.GetComponentInParent(typeof(transparencyObject)) as transparencyObject;
                //print(tObject.name);
                if(!objectsToQuit.Contains(tObject)){
                    objectsToQuit.Add(tObject);
                }
            }
        }
    }

    private void MakeObjectsTransparent(){
        for( int i = 0; i< objectsToQuit.Count; i++){
            transparencyObject objectT = objectsToQuit[i];
            if(!objectsAlreadyT.Contains(objectT)){
                objectT.ShowTransparent();
                objectsAlreadyT.Add(objectT);
            }
        }
    }
    
    private void MakeObjectsSolid(){
        for( int i = objectsAlreadyT.Count-1; i >= 0; i--){
            transparencyObject objectT = objectsAlreadyT[i];

            if(!objectsToQuit.Contains(objectT)){
                objectT.ShowSolid();
                objectsAlreadyT.Remove(objectT);
            }
        }
    }

}