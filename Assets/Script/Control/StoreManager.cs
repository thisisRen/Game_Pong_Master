using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StoreManager : MonoBehaviour
{
    public static StoreManager Instance;

    public DATA_CUP cup;

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
        Cup();
    }
    public void Cup()  //Cup Button
    {
        leftButton.enabled = false;
        rightButton.enabled = false;
        store.GetComponent<ShowUIStore>().ShowCup();
    }
    public void Ball() //Ball button
    {
        leftButton.enabled = true;
        rightButton.enabled = true;
        TurnLeft();
    }
    public void Back() //Back button
    {
        cup.SaveData();
        gameObject.SetActive(false);
    }
    public void TurnLeft()
    {
        store.GetComponent<ShowUIStore>().ShowBall1();
    }
    public void TurnRight()
    {
        store.GetComponent<ShowUIStore>().ShowBall2();
    }

}
