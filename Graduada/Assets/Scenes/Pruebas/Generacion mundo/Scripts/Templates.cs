using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Templates : MonoBehaviour
{
    public GameObject[] BottomRooms;
    public GameObject[] TopRooms;
    public GameObject[] LeftRooms;
    public GameObject[] RightRooms;
    public GameObject enemy;
    public int maxHab;
    public static int numHab;
    public static bool bar;
    void Start(){
            StartCoroutine(esperar(10));
            
        }
        private IEnumerator esperar(int segundos){
            yield return new WaitForSeconds(segundos);
            if(bar == false){
                SceneManager.LoadScene(4);
            }
        }
        
}
