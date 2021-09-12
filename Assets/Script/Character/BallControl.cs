using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public CircleCollider2D col;

    public static bool ballIncup;
    [HideInInspector] public Vector3 pos {
        get { return transform.position;}
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
        ballIncup = false;
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
        GetComponent<ParticleSystem>().Play();

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Cup" && collision.collider.GetType() == typeof(BoxCollider2D))
        {
            ballIncup = true;
        }

    }

}
