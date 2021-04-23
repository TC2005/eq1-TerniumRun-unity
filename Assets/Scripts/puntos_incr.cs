using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class puntos_incr : MonoBehaviour
{
    private Text msg;
    private string textstr;
    Datos_Partida datosPartida;
    // Start is called before the first frame update
    void Start()
    {
        GameObject target = GameObject.FindGameObjectWithTag("Datos");
        datosPartida = target.GetComponent<Datos_Partida>();
        msg = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        msg.text = ((int)datosPartida.tiempo).ToString()+ "seg";
    }
}
