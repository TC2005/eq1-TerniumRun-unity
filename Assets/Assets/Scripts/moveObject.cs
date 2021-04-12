using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveObject : MonoBehaviour
{
    public float speed;
    public Vector2 movement;
    public float x_org;
    public float x_limit;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movement * speed * 100* Time.deltaTime);
        if (transform.position.x <= x_limit)
        {
            transform.position = new Vector2(x_org, transform.position.y);
        }
    }
}
