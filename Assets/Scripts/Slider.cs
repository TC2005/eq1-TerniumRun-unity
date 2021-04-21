using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Sliderchangevolumen : MonoBehaviour
{
    Slider barra;
    Volumen volumen;
    private GameObject target;
    public string cambia;
    void Awake()
    {
        target = GameObject.FindWithTag("Volumen");
        volumen = target.GetComponent<Volumen>();
    }
    // Start is called before the first frame update
    void Start()
    {
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
