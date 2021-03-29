using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class puntos_incr : MonoBehaviour
{
    public float segf;
    private int segi;
    private int lsegi;
    private Text msg;
    private string textstr;

    // Start is called before the first frame update
    void Start()
    {
        segf = 0f;
        segi = 0;
        msg = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        segf += Time.deltaTime;
        segi = (int)segf;
        if (lsegi != segi)
        {
            msg.text = segi.ToString()+ "seg";
        }
        lsegi = segi;
    }
}
