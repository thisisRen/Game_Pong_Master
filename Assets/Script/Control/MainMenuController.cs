using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public static MainMenuController Instance;

    public GameObject store, mainMenu, chapter, setting;
    public DATA_CUP cup;
    public DATA_BALL ball;
    public DATALEVEL level;
    public Text maxLevel;
    public Text coin;

    [SerializeField] private RectTransform ballIcon;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        

        coin.text = PlayerPrefs.GetInt("Coin").ToString();

        ball.SaveData();
        level.SaveData();
        cup.SaveData();
        //savedata() all to update new data
        ball.LoadData();
        level.LoadData();
        cup.LoadData();
        FindObjectOfType<AudioManager>().PlayMusic("MusicMainGame");

        maxLevel.text = "Level " + (PlayerPrefs.GetInt("MaxLevel")+1).ToString();

        

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
    
    public void UseButton()
    {
        cup.SaveData();
        ball.SaveData();
    }
    public void LevelCurrent()
    {
        SceneManager.LoadScene(1);
    }
    
}
