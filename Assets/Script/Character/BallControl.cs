using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public CircleCollider2D col;

    public static bool ballIncup;

    public DATA_BALL data;

    public ParticleSystem ball, breakBall;


    [HideInInspector] public Vector3 pos {
        get { return transform.position;}
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
        ballIncup = false;
    }
    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = data.StoreBall[data.FindIndexStoreChoose()].avatar;
        ball.transform.position = gameObject.transform.position;
        breakBall.transform.position = gameObject.transform.position;
    }
    private void Update()
    {
        
    }
    public void Push(Vector2 force)
    {
        rb.AddForce(force, ForceMode2D.Impulse);
    }
    public void ActivateRb()
    {
        rb.isKinematic = false;
    }
    public void DeactivateRb()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0f;
        rb.isKinematic = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ball.Play();
        if (collision.collider.tag == "Saw")
        {
            breakBall.Play();
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            gameObject.GetComponent<Renderer>().enabled = false;
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Cup")
        {
            ballIncup = true;

          
        }
        

    }

}
