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
    public DATA_CUP data;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        hideCup = new Vector3(0, 0, 0);
        gameObject.GetComponent<SpriteRenderer>().sprite = data.StoreCup[data.FindIndexStoreChoose()].avatar;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<RectTransform>().position.y < -5f && GameManager.done < GameController.Instance.numCup)
        {
            
            GamePongMaster.Lose.Invoke();
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Ball" )
        {


            FindObjectOfType<AudioManager>().PlayEffect("CollectCup");
            GameManager.done += 1;

            gameObject.GetComponent<BoxCollider2D>().enabled = false;

            animatorEffect.SetBool("effect", true);
            collider.GetComponent<Renderer>().enabled = false;
            collider.gameObject.SetActive(false);

            StartCoroutine(HideCup());
        }
        
    }

    private IEnumerator HideCup()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.GetComponent<Transform>().DOScale(hideCup, 0.5f).OnComplete(() =>
        {
            
            gameObject.GetComponent<RectTransform>().DOKill();
            Destroy(gameObject);
        });
    }
    
    
    
}
