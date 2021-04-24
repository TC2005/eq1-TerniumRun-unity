using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonido : MonoBehaviour
{
    public float tiempo;
    float tiempoa=0f;
    public string tipo;
    Volumen volumen;
    private GameObject target;
    AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        target = GameObject.FindWithTag("Volumen");
        volumen = target.GetComponent<Volumen>();

        if (tipo == "effect")
        {
            sound.volume = volumen.effectvolumen;
        }
        else if (tipo == "music")
        {
            sound.volume = volumen.musicvolumen;
        }
    }

    // Update is called once per frame
    void Update()
    {
        tiempoa += Time.deltaTime;
        if (tiempoa > tiempo && tiempo>0) Destroy(gameObject);
        if (tipo == "effect")
        {
            sound.volume = volumen.effectvolumen;
        }
        else if (tipo == "music")
        {
            sound.volume = volumen.musicvolumen;
        }
    }
}
