using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CompleteGame : MonoBehaviour
{
    public DATALEVEL data;
    public Image[] star;
    public Sprite starCompleted;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        NumberStar();
        SetStarLevel();
        SetStarAnim();
    }
    private int NumberStar()
    {
        if(GameManager.NumberBallUse() == GameController.Instance.numCup)
        {
            return 3;
        }
        else if(GameManager.NumberBallUse() > GameController.Instance.numCup && GameManager.NumberBallUse() < GameController.Instance.numberBall)
        {
            return 2;
        }
        else
        {
            return 1;
        }
        
       
    }
    private void SetStarLevel()
    {
        if(NumberStar() > data.listLevel[data.FindIndexListChoosing()].stars)
        {
            data.listLevel[data.FindIndexListChoosing()].stars = NumberStar();
            
        }

        if(data.listLevel[data.FindIndexListChoosing()+1].isPlay == false)
        {
            data.listLevel[data.FindIndexListChoosing() + 1].isPlay = true;
        }
    }
    private void SetStarAnim()
    {
        for(int i=0; i< NumberStar(); i++)
        {
            star[i].sprite = starCompleted;
        }
    }
    public void NextLevel()
    {
       // Destroy(LoadGamePlay.Instance.gamePlay);

        data.listLevel[data.FindIndexListChoosing() + 1].current = true;
        data.Refresh(data.FindIndexListChoosing() + 1);
        LoadGamePlay.Instance.LoadGame();
        SceneManager.LoadScene(1);

        
    }
}
