using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pregunta : MonoBehaviour
{
    private GameObject target;
    BuscadorPreguntas datos;
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
        if (texto.text != "")
        {
            datos = target.GetComponent<BuscadorPreguntas>();
            if (datos.pregunta != "")
            {
                texto.text = datos.pregunta;
            }
        }
    }
}
