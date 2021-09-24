using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLose : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Wall")
        {

            GamePongMaster.Lose?.Invoke();
        }
    }
}
