using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class StoreManager : MonoBehaviour
{
    public static StoreManager Instance;

    public DATA_CUP cup;
    public DATA_BALL ball;
    public GameObject store, menu;

    public GameObject cupParent, ballParent1, ballParent2;

    public Button leftButton, rightButton;
    public Text myCoin;
    public Button useButton;
    public Text useButtonText;
    public Image coinInButton;

    public Sprite buy, bought;

    private bool cupMode;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        store.GetComponent<ShowUIStore>().ShowCup();
        store.GetComponent<ShowUIStore>().ShowBall();
        Cup();

    }
    public void Cup()  //Cup Button
    {
        cupMode = true;
        leftButton.gameObject.SetActive(false);
        rightButton.gameObject.SetActive(false);
        cupParent.SetActive(true);
        ballParent1.SetActive(false);
        ballParent2.SetActive(false);
    }
    public void Ball() //Ball button
    {
        cupMode = false;
        leftButton.gameObject.SetActive(true);
        rightButton.gameObject.SetActive(true);
        cupParent.SetActive(false);
        ballParent2.SetActive(false);
        ballParent1.SetActive(true);
    }
    public void Back() //Back button
    {
        gameObject.SetActive(false);
        menu.SetActive(true);
    }
    public void Left()
    {
        Ball();
    }
    public void Right()
    {
        cupParent.SetActive(false);
        ballParent1.SetActive(false);
        ballParent2.SetActive(true);
    }
    public void UseButtonCup()
    {
        if(cupMode == true)
        {
            if (useButtonText.text == "USE")
            {
                cup.StoreCup[CupElement.Instance.AvatarCurrent()].IsChoose = true;
                cup.Refresh(CupElement.Instance.AvatarCurrent());

            }
            else if (useButton.GetComponent<Image>().sprite == buy)
            {
                int t = PlayerPrefs.GetInt("Coin");
                if (cup.StoreCup[CupElement.Instance.AvatarCurrent()].Price <= t)
                {
                    t -= cup.StoreCup[CupElement.Instance.AvatarCurrent()].Price;
                    FindObjectOfType<AudioManager>().PlayEffect("Buy");
                    cup.StoreCup[CupElement.Instance.AvatarCurrent()].IsBuy = true;
                    PlayerPrefs.SetInt("Coin", t);
                    myCoin.DOText(PlayerPrefs.GetInt("Coin").ToString(), 1f, true, ScrambleMode.None, null).OnComplete(() =>
                    {
                        myCoin.DOKill();
                    });
                }
            }

            cup.SaveData();
        }
    }
    public void UseButtonBall()
    {
        if(cupMode == false)
        {
            if (useButtonText.text == "USE")
            {
                ball.StoreBall[BallElement.Instance.AvatarCurrent()].IsChoose = true;
                ball.Refresh(BallElement.Instance.AvatarCurrent());

            }
            else if (useButton.GetComponent<Image>().sprite == buy)
            {
                int t = PlayerPrefs.GetInt("Coin");
                if (ball.StoreBall[BallElement.Instance.AvatarCurrent()].Price <= t)
                {
                    t -= ball.StoreBall[BallElement.Instance.AvatarCurrent()].Price;
                    FindObjectOfType<AudioManager>().PlayEffect("Buy");

                    ball.StoreBall[BallElement.Instance.AvatarCurrent()].IsBuy = true;
                    PlayerPrefs.SetInt("Coin", t);
                    myCoin.DOText(PlayerPrefs.GetInt("Coin").ToString(), 1f, true, ScrambleMode.None, null).OnComplete(() =>
                    {
                        myCoin.DOKill();
                    });
                }
            }

            ball.SaveData();
        }
        

    }

}
