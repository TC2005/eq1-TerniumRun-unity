using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class abrirTrivia : MonoBehaviour
{
    Datos_Partida datosPartida;
    BuscadorPreguntas preguntas;
    float esperando=0;
    // Start is called before the first frame update
    void Start()
    {
        GameObject target;
        target = GameObject.FindGameObjectWithTag("Datos");
        datosPartida = target.GetComponent<Datos_Partida>();
        target = GameObject.FindGameObjectWithTag("Buscador Preguntas");
        preguntas = target.GetComponent<BuscadorPreguntas>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Feedback");
        if (targets.Length == 0 && datosPartida.empezado)
        {
            esperando += Time.deltaTime;
            if(datosPartida.tipo == "Trivia" && esperando >= 1)
            {
                preguntas.setvalues();
                SceneManager.LoadScene("Trivia", LoadSceneMode.Additive);
                esperando = 0;
            }
            if (datosPartida.tipo == "Normal" && esperando >= 20)
            {
                preguntas.setvalues();
                SceneManager.LoadScene("Trivia", LoadSceneMode.Additive);
                esperando = 0;
            }
        }
    }
}
