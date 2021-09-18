using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSoundGame : MonoBehaviour
{
    public DATA_MENU dataMenu;

    private void Awake()
    {
        if (dataMenu.Sound[0].onSound)
        {
            GamePongMaster.Music += MusicMainGame;
        }
        if (dataMenu.Sound[1].onSound)
        {
           // GamePongMaster.Music += EffectSound;
        }
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    //MUSIC
    private void MusicMainGame()
    {
        FindObjectOfType<AudioManager>().Play("MusicMainGame");
    }
    private void Completed()
    {
        FindObjectOfType<AudioManager>().Play("Complete");
    }
    private void GameOver()
    {
        FindObjectOfType<AudioManager>().Play("GameOver");
    }

    //EFFECT

}
