using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Datos_Partida : MonoBehaviour
{
    public string fechayhora;
    public string idjugador;
    public string tipo;
    public string idtrivia;
    public float tiempo;
    public int rhechas;
    public int rcorrecto;
    public int rincorrecto;
    public int penemigos, pdistancia, ppreguntas;
    public bool empezado;
    public int vida;
    // Start is called before the first frame update
    void Start()
    {
        restart();
    }

    // Update is called once per frame
    void Update()
    {
        if (vida == 0)
        {
            Debug.Log("Se han reiniciado los datos");
            SceneManager.LoadScene("Pantalla de inicio", LoadSceneMode.Single);
            restart();
        }
    }
    public void restart()
    {
        Time.timeScale = 1f;
        empezado = false;
        vida = 3;
        fechayhora = System.DateTime.Now.Day.ToString() + "/" + System.DateTime.Now.Month.ToString() + "/" + System.DateTime.Now.Year.ToString() + " "
                   + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString();
        tiempo = 0f;
        rhechas = 0;
        rcorrecto = 0;
        rincorrecto = 0;
        penemigos = 0;
        pdistancia = 0;
        ppreguntas = 0;
    }
}
