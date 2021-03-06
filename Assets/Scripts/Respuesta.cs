using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Respuesta : MonoBehaviour
{
    private GameObject target;
    BuscadorPreguntas datos;
    public int numero;
    Text texto;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Buscador Preguntas");
        datos = target.GetComponent<BuscadorPreguntas>();
        texto = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(texto.text != "")
        {
            datos = target.GetComponent<BuscadorPreguntas>();
            if (datos.answers[numero] != "")
            {
                texto.text = datos.answers[numero];
            }
        }
    }
    public void clickeado()
    {
        GameObject target = GameObject.FindGameObjectWithTag("Datos");
        Datos_Partida datosPartida = target.GetComponent<Datos_Partida>();
        if (datos.correcta == numero+1)
        {
            datosPartida.vida += 1;
            datosPartida.ppreguntas += 200;
            datosPartida.rcorrecto++;
            datosPartida.rhechas++;
            Debug.Log("Correcto");
        }
        else
        {
            datosPartida.rincorrecto++;
            datosPartida.vida--;
            datosPartida.rhechas++;
            Debug.Log("Incorrecto");
        } 
            
    }
}
