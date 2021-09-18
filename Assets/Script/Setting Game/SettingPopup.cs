using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingPopup : MonoBehaviour
{
    public GameObject menu;
    public DATA_MENU data;

    public Image music, effect; 
    public List<Sprite> listSprite; //0 sound on - 1 sound off - 2 effect on - 3 effect off

    public void Sound()
    {
        
    }
    private void Show()
    {
        if (data.Sound[0].onSound)
        {
            music.sprite = listSprite[0];
        }
        else
        {
            music.sprite = listSprite[1];
        }

        if (data.Sound[1].onSound)
        {
            effect.sprite = listSprite[2];
        }
        else
        {
            effect.sprite = listSprite[3];
        }
    }
    public void Home()
    {
        data.SaveData();
        gameObject.SetActive(false);
        menu.SetActive(true);
    }

    public void SoundGame()
    {
        if (data.Sound[0].onSound)
        {
            data.Sound[0].onSound = false;
        }
        else
        {
            data.Sound[0].onSound = true;
        }
        Show();
    }

    public void Effect()
    {
        if (data.Sound[1].onSound)
        {
            data.Sound[1].onSound = false;
        }
        else
        {
            data.Sound[1].onSound = true;
        }
        Show();
    }
}
