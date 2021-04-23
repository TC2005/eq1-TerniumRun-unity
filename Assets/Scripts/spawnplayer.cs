using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnplayer : MonoBehaviour
{
    public int numero;
    public float x;
    public float y;
    public bool reponte;
    Datos_Partida datosPartida;
    // Start is called before the first frame update
    void Start()
    {
        GameObject target = GameObject.FindGameObjectWithTag("Datos");
        datosPartida = target.GetComponent<Datos_Partida>();
        datosPartida.cambia_skin(x, y, reponte);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
