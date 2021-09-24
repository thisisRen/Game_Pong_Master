using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingPopup : MonoBehaviour
{
    public static SettingPopup Instance;
    public GameObject menu;
    public DATA_MENU dataMenu;

    public Image music, effect; 
    public List<Sprite> listSprite; //0 sound on - 1 sound off - 2 effect on - 3 effect off

    private void Awake()
    {  
        Instance = this;
    }
    private void Show()
    {
        if (dataMenu.Sound[0].onSound)
        {
            music.sprite = listSprite[0];

        }
        else
        {
            music.sprite = listSprite[1];
        }

        if (dataMenu.Sound[1].onSound)
        {
            effect.sprite = listSprite[2];
        }
        else
        {
            effect.sprite = listSprite[3];
        }
    }
    private void Update()
    {
        Show();
    }
    public void Home()
    {
        dataMenu.SaveData();
        gameObject.SetActive(false);
        menu.SetActive(true);
    }

    public void SoundGame()
    {
        if (dataMenu.Sound[0].onSound)
        {
            dataMenu.Sound[0].onSound = false;
     
        }
        else
        {
            dataMenu.Sound[0].onSound = true;
            
        }
        Show();
    }

    public void Effect()
    {
        if (dataMenu.Sound[1].onSound)
        {
            dataMenu.Sound[1].onSound = false;
        
        }
        else
        {
            dataMenu.Sound[1].onSound = true;
            
        }
        Show();
    }
   
}
