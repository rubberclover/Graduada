using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class acciones_Street : MonoBehaviour
{

    //Player player
    //Array inventario
    ChangeLevelLogic level = new ChangeLevelLogic();
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetButton("Uber")){
            returnHome();
        }
    }

    private void returnHome(){
        //Iniciar animacion
        //Cargar inventario de player en el array del inventario
        //Eliminar la mitad del inventario de forma aleatoria
        // ¿Enviar el inventario a el inventario del piso ?
        level.start();

    }
}
