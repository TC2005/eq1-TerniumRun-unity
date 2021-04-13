using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonido : MonoBehaviour
{
    public float tiempo;
    public string tipo;
    NoDestruir volumen;
    private GameObject target;
    AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        target = GameObject.FindWithTag("Volumen");
        volumen = target.GetComponent<NoDestruir>();

        if (tipo == "effect")
        {
            sound.volume = volumen.effectvolumen;
        }
        else if (tipo == "music")
        {
            sound.volume = volumen.musicvolumen;
        }
        Destroy(gameObject, tiempo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
