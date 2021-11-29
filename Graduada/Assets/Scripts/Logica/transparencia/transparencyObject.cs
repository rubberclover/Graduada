using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transparencyObject : MonoBehaviour
{
    [SerializeField] private GameObject solid;

    [SerializeField] private GameObject transparent;

    void Start()
    {
        ShowSolid();
    }

    public void ShowSolid(){
        solid.SetActive(true);
        transparent.SetActive(false);
    }
    public void ShowTransparent(){
        solid.SetActive(false);
        transparent.SetActive(true);
    }
}
