using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuscadorPreguntas : MonoBehaviour
{
    public string pregunta;
    public string[] answers = new string[4];
    public string feedback;
    public int correcta = -1;
    // Start is called before the first frame update
    void Start()
    {
        //Se necesita hacer por peticiones http
        pregunta = "Un stock con semaforo amarillo significa que...";
        answers[0] = "esta disponible";
        answers[1] = "no esta disponible";
        answers[2] = "tiene una condicion a revisar";
        answers[3] = "el producto ya no tendra stock";
        feedback = "Verde significa disponible. Rojo no disponible y amarillo que tiene alguna condicion a revisar.";
        correcta = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
