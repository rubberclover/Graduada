using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtagonistaVida : MonoBehaviour
{
    public int health;

    //100 health 

    public void LoseHealth(int value){
        health -= value;
    }

    public void GainHealth(int value){
       health += value; 
    }
}
