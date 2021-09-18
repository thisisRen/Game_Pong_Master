using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject store, mainMenu, chapter, setting;
    public DATA_CUP cup;
    public DATA_BALL ball;
    public DATALEVEL level;
    void Start()
    {
        ball.SaveData();
        level.SaveData();
        cup.SaveData();
        //savedata() all to update new data
        ball.LoadData();
        level.LoadData();
        cup.LoadData();
    }

    public void ShowStore()
    {
        mainMenu.SetActive(false);
        store.SetActive(true);

    }
    public void Chapter()
    {
        mainMenu.SetActive(false);
        chapter.SetActive(true);
    }
    public void Setting()
    {
        mainMenu.SetActive(false);
        setting.SetActive(true);
    }
}
