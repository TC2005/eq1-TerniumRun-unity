using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveEnemigo : MonoBehaviour
{
    public float speed;
    public Vector2 movement;
    public Vector2 xy_org;
    public float x_min;
    public float x_max;
    public float y_min;
    public float y_max;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = xy_org;
        speed *= Random.Range(1f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movement * speed * 100 * Time.deltaTime);
        if (transform.position.x > x_max || transform.position.y >y_max || transform.position.x < x_min || transform.position.y < y_min)
        {
            Destroy(gameObject);
        }
    }
}
