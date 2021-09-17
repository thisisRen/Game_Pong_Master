using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StoreManager : MonoBehaviour
{
    public static StoreManager Instance;

    public DATA_CUP cup;
    public DATA_BALL ball;
    public GameObject store;

    

    public Button leftButton, rightButton;
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
        leftButton.gameObject.SetActive(false);
        rightButton.gameObject.SetActive(false);
    }
    public void Ball() //Ball button
    {
        leftButton.gameObject.SetActive(true);
        rightButton.gameObject.SetActive(true);
    }
    public void Back() //Back button
    {
        cup.SaveData();
        ball.SaveData();
        gameObject.SetActive(false);

    }
   

}
