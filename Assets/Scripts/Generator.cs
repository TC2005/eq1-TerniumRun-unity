using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject myPrefab;
    public float tiempo_primero;
    public float tiempo_rep;
    public float probabilidad_rep;

    void Start()
    {
        InvokeRepeating("CreaObjeto", tiempo_primero, tiempo_rep);
    }

    // Update is called once per frame
    void Update()
    {
    }
    void CreaObjeto()
    {
        if(Random.Range(0f,1f) < probabilidad_rep)
        {
            GameObject generado = Instantiate(myPrefab, new Vector2(10, 10), Quaternion.identity);
        }
    }
}
