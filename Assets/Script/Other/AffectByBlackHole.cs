using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AffectByBlackHole : MonoBehaviour
{
    private GameObject blackHole;
    public float gravityRadius; // khoang cach tac dong len vat the
    public float gravityConstant; //luc hap dan tu ho den
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        blackHole = GameObject.Find("Hole");
        
    }


    void Update()
    {
        this.transform.position = transform.position;
    }

    public void CallStart()
    {

        Vector2 gravityVector = blackHole.transform.position - transform.position; // vecto kc tu ho den -> thien thach
        float dot = Vector2.Dot(gravityVector, rb.velocity);
        float a = gravityVector.magnitude;
        float b = rb.velocity.magnitude;


        float gravityDistance = Vector2.Distance(blackHole.transform.position, transform.position); // khoang cach giua ho den va thien thach

        Vector2 gravityStrength = Vector2.zero;
        gravityStrength.x = gravityConstant / Mathf.Pow(gravityDistance, 2);
        gravityStrength.y = gravityConstant / Mathf.Pow(gravityDistance, 2);

        if (gravityDistance < gravityRadius)
        {
            Vector2 move = Vector3.Scale(gravityStrength, gravityVector); // nhan 2 vector



            rb.velocity = rb.velocity + move;
        }
    }
}
