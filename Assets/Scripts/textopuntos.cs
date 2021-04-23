using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textopuntos : MonoBehaviour
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
        msg.text = (datosPartida.pdistancia + datosPartida.penemigos + datosPartida.ppreguntas).ToString();
    }
}
