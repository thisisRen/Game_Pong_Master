using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class PausePopup : MonoBehaviour
{
    public Text level;
    public DATALEVEL data;
   
    void Start()
    {
        int t = data.listLevel[data.FindIndexListChoosing()].ID + 1;
        level.text = "LEVEL " + t.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        
    }
    public void Chapter()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void Continue()
    {
        this.GetComponent<RectTransform>().DOLocalMoveX(-2341, 0.3f).SetUpdate(true).OnComplete(() =>
        {
            Time.timeScale = 1f;

            gameObject.SetActive(false);
        });
       
    }

    public void UIMove()
    {

        this.GetComponent<RectTransform>().DOLocalMoveX(0, 0.3f).SetUpdate(true);
    }

}
