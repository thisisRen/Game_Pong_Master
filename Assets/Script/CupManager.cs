using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CupManager : MonoBehaviour
{
    public static CupManager Instance;
    public Animator animatorEffect;
    public static bool gameOver = false;
    private Vector2 hideCup;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        hideCup = new Vector3(0, 0, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.tag == "Ball" && BallControl.ballIncup== true)
        {
            animatorEffect.SetBool("effect", true);
            collider.GetComponent<Renderer>().enabled = false;
            StartCoroutine(HideCup());

        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Ball" && BallControl.ballIncup == true)
        {

            GameManager.Instance.done += 1;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private IEnumerator HideCup()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.GetComponent<RectTransform>().DOScale(hideCup, 0.5f).OnComplete(() =>
        {
            
            gameObject.GetComponent<RectTransform>().DOKill();

        });
    }
    
    
    
}
