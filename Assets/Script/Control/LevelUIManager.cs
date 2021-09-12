using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelUIManager : MonoBehaviour
{
    [Header("UI Manager")]
    public GameObject pausePopup;

    public Text target;
    public Image imageTarget;
    public Sprite cup, star, glass;

    public Text modeGameText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowUI();
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        pausePopup.SetActive(true);
    }
    public void Continue()
    {
        Time.timeScale = 1f;
        pausePopup.SetActive(false);
    }
    public void Home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    private void ShowUI()
    {
        if ( GameController.Instance.modeGame == ModeGame.Mode.BEER)
        {
            imageTarget.sprite = cup;
            target.text = GameController.Instance.numCup.ToString();
            modeGameText.text = "Pong Beer Game";

        }
        else if(GameController.Instance.modeGame == ModeGame.Mode.STAR)
        {
            imageTarget.sprite = star;
            target.text = GameController.Instance.numStar.ToString();
            modeGameText.text = "Pong Star Game";
        }
        else
        {
            imageTarget.sprite = glass;
            target.text = GameController.Instance.numGlass.ToString();
            modeGameText.text = "Pong Break Game";
        }
        
    }
    private void ShowModeGame()
    {
       
    }
 
}
