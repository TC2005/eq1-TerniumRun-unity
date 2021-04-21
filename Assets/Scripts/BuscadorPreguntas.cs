using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BuscadorPreguntas : MonoBehaviour
{
    public string pregunta;
    public string[] answers = new string[4];
    public string feedback;
    public int correcta = -1;
    public int gameid;
    public class Tablapregunta
    {
        public Tablapregunta()
        {
            game_id = 0;
            pregunta = "";
            answers = new List<string>();
            feedback = "";
            correcta = 0;
            status = true;
        }
        public int game_id;
        public string pregunta;
        public List<string> answers;
        public string feedback;
        public int correcta;
        public bool status;
    }
    public List<Tablapregunta> todas = new List<Tablapregunta>();
    int tam = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("GetText");
    }
    public void setvalues()
    {
        int rand = (int)UnityEngine.Random.Range(0f, (float)tam);
        pregunta = todas[rand].pregunta;
        answers[0] = todas[rand].answers[0];
        answers[1] = todas[rand].answers[1];
        answers[2] = todas[rand].answers[2];
        answers[3] = todas[rand].answers[3];
        feedback = todas[rand].feedback;
        correcta = todas[rand].correcta;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator GetText()
    {
        string url = "http://localhost:5000/question/get-questions?game_id="+gameid.ToString();

        UnityWebRequest www = UnityWebRequest.Get(url);
        
        yield return www.SendWebRequest();

        string textoJSON = www.downloadHandler.text;
        for (int i = 0; i < textoJSON.Length; i++) {
            if (textoJSON[i] == '"')
            {
                string parametro = "";
                int j = 1;
                while (textoJSON[i + j] != '"')
                {
                    parametro += textoJSON[i + j];
                    j++;
                }

                i += j + 1;
                string valor = "";
                j = 2;
                while (textoJSON[i + j] != ',' && textoJSON[i + j] != '\n')
                {
                    if (textoJSON[i + j] != '"') valor += textoJSON[i + j];
                    j++;
                }
                i += j + 1;
                //Switch de parametro
                if (parametro == "game_id")
                {
                    tam++;
                    todas.Add(new Tablapregunta());
                    todas[tam - 1].game_id = Convert.ToInt32(valor);
                    //Debug.Log(todas[tam - 1].game_id);
                }
                else if (parametro == "question")
                {
                    todas[tam - 1].pregunta = valor;
                    //Debug.Log(todas[tam - 1].pregunta);
                }
                else if (parametro == "answer1" || parametro == "answer2" || parametro == "answer3" || parametro == "answer4")
                {
                    todas[tam - 1].answers.Add(valor);
                    if (todas[tam - 1].answers.Count == 4)
                    {
                        //Debug.Log(todas[tam - 1].answers[0]);
                        //Debug.Log(todas[tam - 1].answers[1]);
                        //Debug.Log(todas[tam - 1].answers[2]);
                        //Debug.Log(todas[tam - 1].answers[3]);
                    }
                }
                else if (parametro == "justification")
                {
                    todas[tam - 1].feedback = valor;
                    //Debug.Log(todas[tam - 1].feedback);
                }
                else if (parametro == "correct")
                {
                    todas[tam - 1].correcta = Convert.ToInt32(valor);
                    //Debug.Log(todas[tam - 1].correcta);
                }
                else if (parametro == "status")
                {
                    if (valor == "true") todas[tam - 1].status = true;
                    else todas[tam - 1].status = false;
                    //Debug.Log(todas[tam - 1].status);
                }
                //Termina Switch de parametro
            }
        }
        setvalues();
        //Debug.Log("Tamaño de la trivia: "+todas.Count.ToString());
        //Debug.Log(textoJSON);
    }
}
