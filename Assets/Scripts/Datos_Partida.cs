using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class Datos_Partida : MonoBehaviour
{
    public string fechayhora;
    public string idjugador;
    public int idtrivia;
    public string email;
    public string tipo;
    public float tiempo;
    public int rhechas;
    public int rcorrecto;
    public int rincorrecto;
    public int penemigos, pdistancia, ppreguntas;
    public bool empezado;
    public int vida;
    //Corazones
    public GameObject cora;
    SpriteRenderer corarender;
    //Skins
    public GameObject[] skins = new GameObject[4];
    public int idskin = 0;
    // Start is called before the first frame update
    void Start()
    {
        corarender = cora.GetComponent<SpriteRenderer>();
        restart();
    }

    // Update is called once per frame
    void Update()
    {
        if (empezado && tipo == "Normal")
        {
            tiempo += Time.deltaTime;
            pdistancia = (int)tiempo * 10;
        }

        corarender.size = new Vector2(vida * 0.18f, 0.165f);
        if (vida == 0)
        {
            Debug.Log("Se han reiniciado los datos");
            StartCoroutine("subirdatos");
            SceneManager.LoadScene("Game Over", LoadSceneMode.Additive);
            empezado = false;
            vida = 1;
        }
        if (vida > 10) vida = 10;
    }
    public void restart()
    {
        Time.timeScale = 1f;
        empezado = false;
        vida = 3;
        fechayhora = System.DateTime.Now.Day.ToString() + "/" + System.DateTime.Now.Month.ToString() + "/" + System.DateTime.Now.Year.ToString() + " "
                   + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString();
        tiempo = 0f;
        rhechas = 0;
        rcorrecto = 0;
        rincorrecto = 0;
        penemigos = 0;
        pdistancia = 0;
        ppreguntas = 0;
    }
    IEnumerator subirdatos()
    {
        string url = "http://localhost:5000/roundgame/add-roundgame";
        WWWForm form = new WWWForm();
        form.AddField("gameID", idtrivia);
        form.AddField("userID", idjugador);
        form.AddField("userEmail", email);
        form.AddField("gameType", tipo);
        form.AddField("time", tiempo.ToString());
        form.AddField("answered", rhechas);
        form.AddField("incorrect", rincorrecto);
        form.AddField("correct", rcorrecto);
        form.AddField("score", (pdistancia + penemigos + ppreguntas).ToString());
        UnityWebRequest www = UnityWebRequest.Post(url, form);

        yield return www.SendWebRequest();
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
    }
    public void idskin_resta()
    {
        idskin--;
        if (idskin < 0) idskin = skins.Length - 1;
        GameObject target = GameObject.FindGameObjectWithTag("Player");
        Destroy(target.gameObject);
        cambia_skin(0,-0.65f,false);
    }
    public void idskin_suma()
    {
        idskin++;
        if (idskin >= skins.Length) idskin = 0;
        GameObject target = GameObject.FindGameObjectWithTag("Player");
        Destroy(target.gameObject);
        cambia_skin(0, -0.65f, false);
    }
    public void cambia_skin(float x, float y, bool reponte)
    {
        GameObject target = Instantiate(skins[idskin]);
        Player player = target.GetComponent<Player>();
        player.reponte = reponte;
        target.transform.position = new Vector2(x, y);
    }
}
