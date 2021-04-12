using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;

public class SliderChangeVolumen : MonoBehaviour
{
    Slider barra;
    NoDestruir volumen;
    private GameObject target;
    public string cambia;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Volumen");
        volumen = target.GetComponent<NoDestruir>();
        barra = GetComponent<Slider>();

        if (cambia == "effectvolumen")
        {
            barra.value = volumen.effectvolumen;
        }
        else if (cambia == "musicvolumen")
        {
            barra.value = volumen.musicvolumen;
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (cambia == "effectvolumen")
        {
            volumen.effectvolumen = barra.value;
        }
        else if (cambia == "musicvolumen")
        {
            volumen.musicvolumen = barra.value;
        }
    }
}
