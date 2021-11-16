using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProtagonistaVida : MonoBehaviour
{
    public Image[] corazones;
    public int health;

    //100 health 

    public void LoseHealth(){
        health--;
        corazones[health].enabled = false;

        if(health==0){
          Debug.Log("You lose");
        }
    }

    public void GainHealth(int value){
       health += value; 
    }
     private void Update() {
        if(Input.GetKeyDown(KeyCode.M)){
        LoseHealth();
        }
    }
}
