using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class clickplay : MonoBehaviour
{
    public string nombre_escena;
    GameObject target;
    Datos_Partida datosPartida;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Datos");
        datosPartida = target.GetComponent<Datos_Partida>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (!datosPartida.empezado)
        {
            SceneManager.LoadScene(nombre_escena, LoadSceneMode.Single);
        }
        
    }
}
