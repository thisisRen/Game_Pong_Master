using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ChapterManager : MonoBehaviour
{
    public static ChapterManager Instance;
    public DATALEVEL level;
    public GameObject parentLevel, menu;
    public Text chapter;
    public Button left, right;

    public Text starDone, levelDone;
    public Image fillStar, fillLevel;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        parentLevel.GetComponent<ShowUILevel>().ShowLevel();
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowUI();
       
    }
    public void Home()
    {
        level.SaveData();
        gameObject.SetActive(false);
        menu.SetActive(true);
    }
    public void Right()
    {
        if(parentLevel.GetComponent<RectTransform>().position.x > -1845)
            parentLevel.GetComponent<RectTransform>().DOAnchorPosX(-1845, 0.3f).OnComplete(() =>
            {
                parentLevel.GetComponent<RectTransform>().DOKill();
            });
    }
    public void Left()
    {
        if (parentLevel.GetComponent<RectTransform>().position.x < 0)
            parentLevel.GetComponent<RectTransform>().DOAnchorPosX(0, 0.3f).OnComplete(() =>
            {
                parentLevel.GetComponent<RectTransform>().DOKill();
            });
    }
    private void ShowUI()
    {
        if( parentLevel.GetComponent<RectTransform>().position.x >= 0)
        {
          
            right.gameObject.SetActive(true);
            left.gameObject.SetActive(false);
            chapter.text = "CHAPTER 1";
            Fill(0, 9);
        }
        else if(parentLevel.GetComponent<RectTransform>().position.x >= -1845)
        {
          
            left.gameObject.SetActive(true);
            right.gameObject.SetActive(false);
            chapter.text = "CHAPTER 2";
            Fill(9, 17);
        }
    }
    private void Fill(int minLevel, int maxLevel)
    {
        int starD = 0;
        int levelD = 0;
        for(int i= minLevel; i< maxLevel; i++)
        {
            if(level.listLevel[i].stars >= 0)
            {
                starD += level.listLevel[i].stars;
            }
            if (level.listLevel[i].isPlay == true)
            {
                levelD += 1;
            }
        }

        starDone.DOText(starD.ToString(), 0.5f, true, ScrambleMode.None, null).OnComplete(() =>
        {
            starDone.DOKill();
        });
        levelDone.DOText(levelD.ToString(), 0.5f, true, ScrambleMode.None, null).OnComplete(() =>
        {
            starDone.DOKill();
        });

        fillStar.fillAmount = starD / 27;
        fillLevel.fillAmount = levelD / 9;
    }
}
