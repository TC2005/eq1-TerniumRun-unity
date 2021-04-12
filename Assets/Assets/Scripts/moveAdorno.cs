using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveAdorno : MonoBehaviour
{
    public float speed = 0.01f;
    public Vector2 movement = new Vector2(-1f,0);
    public Vector2 xy_org = new Vector2(2.5f,-0.4f);
    public float x_limit = -6f;
    public float sa = 1.5f, sb = 3f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = xy_org;
        float scale = Random.Range(sa, sb);
        transform.localScale = new Vector3(scale,scale,scale);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movement * speed * 100 * Time.deltaTime);
        if (transform.position.x <= x_limit)
        {
            Destroy(gameObject);
        }
    }
}
