using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkHole : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<AffectByBlackHole>() != null)
        {
            collision.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
