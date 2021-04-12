using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoDestruir : MonoBehaviour
{
    public float effectvolumen;
    public float musicvolumen;
    GameObject[] target;
    private void Awake()
    {
        target = GameObject.FindGameObjectsWithTag("Volumen");
        if(target.Length > 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        //AQUI DEBES ACTUALIZAR LOS VALORES POR UNA PETICION HTTP
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
