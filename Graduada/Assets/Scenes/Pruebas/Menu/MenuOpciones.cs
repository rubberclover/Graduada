using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuOpciones : MonoBehaviour
{
    ChangeLevelLogic level = new ChangeLevelLogic();

    public GameObject botonControles,botonVolver;
    private void Start() {
     EventSystem.current.SetSelectedGameObject(botonControles); 
    }
}
