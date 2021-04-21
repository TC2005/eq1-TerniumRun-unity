using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barratiempo : MonoBehaviour
{
    public float tiempo;
    float tiempo_act=0;
    SpriteRenderer SR;
    float xorg;
    float yorg;
    float mseg;
    float mseg_a;
    // Start is called before the first frame update
    void Start()
    {
        xorg = transform.localScale.x;
        yorg = transform.localScale.y;
        SR = GetComponent<SpriteRenderer>();
        SR.color = new Color(0f, 1f, 0f);
        mseg_a = System.DateTime.Now.Millisecond;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale==0f)
        {
            StartCoroutine("chiquito");
            /*
            tiempo_act += Time.deltaTime;
            transform.localScale = new Vector3(xorg * (tiempo - tiempo_act) / tiempo, yorg, 1f);
            SR.color = new Color(1f - (tiempo - tiempo_act) / tiempo, (tiempo - tiempo_act) / tiempo, 0f);
            */
        }
    }
    IEnumerator chiquito()
    {
        mseg = System.DateTime.Now.Millisecond;
        if (mseg < mseg_a) mseg_a -= 1000;
        tiempo_act += (mseg - mseg_a) / 1000;
        transform.localScale = new Vector3(xorg * (tiempo - tiempo_act) / tiempo, yorg, 1f);
        SR.color = new Color(1f - (tiempo - tiempo_act) / tiempo, (tiempo - tiempo_act) / tiempo, 0f);
        mseg_a = mseg;
        if (tiempo_act > tiempo)
        {
            cierra();
            transform.localScale = new Vector3(0f, yorg, 1f);
        }
        yield return new WaitForSeconds(.1f);
    }
    void cierra()
    {
        GameObject target;
        Feedback_Aparece feedback;
        target = GameObject.FindGameObjectWithTag("Feedback");
        feedback = target.GetComponent<Feedback_Aparece>();
        feedback.contestado();
    }
}
