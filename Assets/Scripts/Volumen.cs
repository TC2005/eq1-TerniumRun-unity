using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class Volumen : MonoBehaviour
{
    public float effectvolumen;
    public float musicvolumen;
    public string email;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("ConsultaVolumen");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void actualizaenBD()
    {
        StartCoroutine("SetVolumen");
    }
    IEnumerator ConsultaVolumen()
    {
        string url = "http://localhost:5000/auth/Volumen?email=" + email;
        UnityWebRequest www = UnityWebRequest.Get(url);

        yield return www.SendWebRequest();

        string textoJSON = www.downloadHandler.text;
        for (int i = 0; i < textoJSON.Length; i++)
        {
            if (textoJSON[i] == '"')
            {
                string parametro = "";
                int j = 1;
                while (textoJSON[i + j] != '"')
                {
                    parametro += textoJSON[i + j];
                    j++;
                }

                i += j + 1;
                string valor = "";
                j = 2;
                while (textoJSON[i + j] != ',' && textoJSON[i + j] != '\n')
                {
                    if (textoJSON[i + j] != '"') valor += textoJSON[i + j];
                    j++;
                }
                if (parametro == "effectVolumen")
                {
                    effectvolumen = Convert.ToSingle(valor);
                }
                if(parametro == "musicVolumen")
                {
                    musicvolumen = Convert.ToSingle(valor);
                    break;
                }
            }
        }
        Debug.Log(textoJSON);
    }
    IEnumerator SetVolumen()
    {
        string url = "http://localhost:5000/auth/set-effect-volumen";
        WWWForm form = new WWWForm();
        form.AddField("email", email);
        form.AddField("effectVolumen", effectvolumen.ToString());
        UnityWebRequest www = UnityWebRequest.Post(url, form);


        string url2 = "http://localhost:5000/auth/set-music-volumen";
        WWWForm form2 = new WWWForm();
        form2.AddField("email", email);
        form2.AddField("musicVolumen", musicvolumen.ToString());
        UnityWebRequest www2 = UnityWebRequest.Post(url2, form2);

        yield return www.SendWebRequest();
        yield return www2.SendWebRequest();

        if (www.isNetworkError)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            Debug.Log(www.downloadHandler.text);

            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
        }
        if (www2.isNetworkError)
        {
            Debug.Log(www2.error);
        }
        else
        {
            // Show results as text
            Debug.Log(www2.downloadHandler.text);

            // Or retrieve results as binary data
            byte[] results = www2.downloadHandler.data;
        }
    }
}
