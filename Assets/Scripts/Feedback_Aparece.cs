using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Feedback_Aparece : MonoBehaviour
{
    RectTransform tam;
    float scl = 0f;
    bool contestadoB = false;
    public float tiempo; //Tiempo en segundos
    float tiempo_act;
    float mseg;
    float mseg_a;
    // Start is called before the first frame update
    void Start()
    {
        tam = GetComponent<RectTransform>();
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (scl < 1f && contestadoB)
        {
            StartCoroutine("grande");
        }
    }
    IEnumerator grande()
    {
        mseg = System.DateTime.Now.Millisecond;
        if (mseg < mseg_a) mseg_a -= 1000;
        tiempo_act += (mseg - mseg_a) / 1000;
        transform.localScale = new Vector3(tiempo_act/tiempo, tiempo_act/tiempo, 1f);
        mseg_a = mseg;
        if (tiempo_act > tiempo)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        yield return new WaitForSeconds(.1f);
    }
    public void contestado()
    {
        contestadoB = true;
    }
}
