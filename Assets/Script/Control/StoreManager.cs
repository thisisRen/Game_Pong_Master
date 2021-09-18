using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StoreManager : MonoBehaviour
{
    public static StoreManager Instance;

    public DATA_CUP cup;
    public DATA_BALL ball;
    public GameObject store, menu;

    

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
      
        Cup();

    }
    public void Cup()  //Cup Button
    {
        leftButton.gameObject.SetActive(false);
        rightButton.gameObject.SetActive(false);
        store.GetComponent<ShowUIStore>().ShowCup();
    }
    public void Ball() //Ball button
    {
        leftButton.gameObject.SetActive(true);
        rightButton.gameObject.SetActive(true);
        store.GetComponent<ShowUIStore>().ShowBall();
    }
    public void Back() //Back button
    {
        cup.SaveData();
        ball.SaveData();
        gameObject.SetActive(false);
        menu.SetActive(true);

    }
   

}
