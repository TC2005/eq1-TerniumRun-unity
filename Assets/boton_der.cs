using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boton_der : MonoBehaviour
{
    Datos_Partida datosPartida;
    // Start is called before the first frame update
    void Start()
    {
        GameObject target = GameObject.FindGameObjectWithTag("Datos");
        datosPartida = target.GetComponent<Datos_Partida>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        datosPartida.idskin_suma();
    }
}
