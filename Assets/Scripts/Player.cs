using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float fuerzasalto = 4.5f;
    public Vector2 movement;
    public float speed;
    public float x_max, x_min;
    private bool chiquito;
    public bool reponte;
    //Objeto datos
    Datos_Partida datosPartida;
    //Objeto sonido
    public GameObject jumpsound;
    public GameObject destroyjumpsound;
    public GameObject hurtsound;
    public GameObject fallsound;
    // Start is called before the first frame update
    void Start()
    {
        chiquito = false;
        rb = GetComponent<Rigidbody2D>();
        GameObject target = GameObject.FindGameObjectWithTag("Datos");
        datosPartida = target.GetComponent<Datos_Partida>();
    }

    // Update is called once per frame
    void Update()
    {
        ///SALTA Y BAJA
        if (Input.GetKey(KeyCode.DownArrow))
        {
            chiquito = true;
        }
        else
        {
            chiquito = false;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)   && transform.position.y<=-0.26)
        {
            rb.AddForce(new Vector2(0, fuerzasalto), ForceMode2D.Impulse);
            Instantiate(jumpsound);
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb.AddForce(new Vector2(0, -fuerzasalto), ForceMode2D.Impulse);
            Instantiate(fallsound);
        }
        if (chiquito)
        {
            transform.localScale = new Vector3(1f, 0.3f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        ///VELOCIDAD
        movement.x = Input.GetAxis("Horizontal") * speed;
        if (movement.x < 0)
        {
            movement.x *= 1.5f;
            if (transform.position.x <= x_min)
            {
                movement.x *= 0f;
            }
        }
        else if(movement.x > 0 && transform.position.x >= x_max)
        {
            movement.x *= 0f;
        }
        rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);
        if (transform.position.y <= -0.4 && reponte)
        {
            transform.position = new Vector3(transform.position.x, -0.28f, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Enemy")
        {
            if (transform.position.y >= c.transform.position.y)
            {
                Instantiate(destroyjumpsound);
                rb.AddForce(new Vector2(0, fuerzasalto), ForceMode2D.Impulse);
                Destroy(c.gameObject);
                datosPartida.penemigos += 15;
            }
            else
            {
                Instantiate(hurtsound);
                Destroy(c.gameObject);
                datosPartida.vida--;
                if (datosPartida.vida <= 0f)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
