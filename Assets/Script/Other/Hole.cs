using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<AffectByBlackHole>() != null)
        {
            collision.GetComponent<AffectByBlackHole>().CallStart();
        }
    }
}
