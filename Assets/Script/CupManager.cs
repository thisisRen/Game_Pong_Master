using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupManager : MonoBehaviour
{
    public static CupManager Instance;
    public Animator animator;
    public static bool gameOver = false;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ball" && BallControl.ballIncup== true)
        {
            animator.SetBool("quite_play", true);
            gameOver = true;
        }
    }
}
