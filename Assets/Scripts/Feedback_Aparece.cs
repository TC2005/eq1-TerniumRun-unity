using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feedback_Aparece : MonoBehaviour
{
    RectTransform tam;
    float scl = 0f;
    bool contestadoB = false;
    public float t; //Tiempo en segundos
    // Start is called before the first frame update
    void Start()
    {
        tam = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (scl < 1f && contestadoB)
        {
            tam.localScale = new Vector3(scl, scl, scl);
            scl += Time.deltaTime / t;
        }
    }
    public void contestado()
    {
        contestadoB = true;
    }
}
