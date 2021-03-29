using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class clickplay : MonoBehaviour
{
    public string nombre_escena;
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
        SceneManager.LoadScene(nombre_escena, LoadSceneMode.Single);
    }
}
