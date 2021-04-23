using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botontipo : MonoBehaviour
{
    Datos_Partida datosPartida;
    public string tipo;

    // Start is called before the first frame update
    void Start()
    {
        GameObject target;
        target = GameObject.FindGameObjectWithTag("Datos");
        datosPartida = target.GetComponent<Datos_Partida>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        datosPartida.tipo = tipo;
        datosPartida.empezado = true;
    }
}
