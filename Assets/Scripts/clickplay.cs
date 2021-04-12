using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class clickplay : MonoBehaviour
{
    public string nombre_escena;
    public string modo;
    GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (modo == "Single")
        {
            SceneManager.LoadScene(nombre_escena, LoadSceneMode.Single);
        }
        else if (modo == "Additive")
        {
            SceneManager.LoadScene(nombre_escena, LoadSceneMode.Additive);
        }
    }
}
