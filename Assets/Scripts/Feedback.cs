using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Feedback : MonoBehaviour
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
            if (datos.feedback != "")
            {
                texto.text = datos.feedback;
            }
        }
    }
    public void clickeado()
    {
        Time.timeScale = 1f;
        SceneManager.UnloadSceneAsync("Trivia");
    }
}