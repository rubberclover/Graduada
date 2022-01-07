using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drops : MonoBehaviour
{
    public List<GameObject> dropeableItems;
    private double chanceCactus;
    private double chanceRefresco;
    private double chanceCalcetin;

    void Start()
    {
        chanceCactus = 0.8f;
        chanceRefresco = 0.5f;
    }

    public void Drop(Vector3 dropPosition){
        int numDrops = Random.Range(1,3);

        for( int j = 0; j< numDrops; j++){
            double dropChance = Random.Range(0.0f,1f);

            if(dropChance >= chanceCactus){
                print("Dropeado un " + "Cactus");
                Instantiate(dropeableItems[2], dropPosition  , Quaternion.identity);
            }
            if(dropChance >= chanceRefresco){
                print("Dropeado un " + "Refresco");
                Instantiate(dropeableItems[1], dropPosition  , Quaternion.identity);
            }
            else{
                print("Dropeado un " + "Calcetin");
                Instantiate(dropeableItems[0], dropPosition  , Quaternion.identity);
            }
        }
    }
}
