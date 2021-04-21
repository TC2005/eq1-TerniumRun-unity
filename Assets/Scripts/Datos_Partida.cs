using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
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
        StartCoroutine("GetText");
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
    IEnumerator GetText()
    {
        string url = "http://localhost:5000/auth/validate-token";
        /*WWWForm form = new WWWForm();
        form.AddField("authToken", token);*/

        UnityWebRequest www = UnityWebRequest.Get(url);
        www.SetRequestHeader("Authorization", "bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzaWQiOiJkOWQ1MzRlMy1kMWM2LTQ4ZTQtODMwZS04YjQwZmVhOGJkMjcifQ.p0p65zvOUuURszZHOqi-93qwcLL7uS5sm1LUohKcK6U");
        yield return www.SendWebRequest();

        if (www.isNetworkError)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            Debug.Log(www.downloadHandler.text);

            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
        }
    }
}
