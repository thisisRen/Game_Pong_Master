using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StarManager : MonoBehaviour
{
    private Vector2 hideStar;
    

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Ball")
        {


            FindObjectOfType<AudioManager>().PlayEffect("CollectStar");

            GameManager.done += 1;
            

            gameObject.GetComponent<Transform>().DOScale(hideStar, 0f).OnComplete(() =>
            {

                gameObject.GetComponent<RectTransform>().DOKill();
                Destroy(gameObject);
            });
        }

    }
}
