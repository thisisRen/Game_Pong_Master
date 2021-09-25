using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ChapterManager : MonoBehaviour
{
    public static ChapterManager Instance;
    public DATALEVEL level;
    public GameObject parentLevel, menu;
    public Text chapter;
    public Button left, right;

    public Text starDone, levelDone;
    public Image fillStar, fillLevel;
    public Image bestStar, bestLevel;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        ShowUI();
        parentLevel.GetComponent<ShowUILevel>().ShowLevel();
        
    }
    private void Update()
    {
        ShowUI();
    }
    // Update is called once per frame
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
     
        }
        else if(parentLevel.GetComponent<RectTransform>().position.x >= -1845)
        {
          
            left.gameObject.SetActive(true);
            right.gameObject.SetActive(false);
            chapter.text = "CHAPTER 2";
    
        }
        Fill();
    }
    private void Fill()
    {
        int starD = 0;
        int levelD = 0;
        for(int i= 0; i< level.listLevel.Count; i++)
        {
            if(level.listLevel[i].stars > 0)
            {
                starD += level.listLevel[i].stars;
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

        fillStar.fillAmount = Mathf.Lerp(fillStar.fillAmount, (float)starD / 54, 3f * Time.deltaTime);

        if(starD == 54)
        {
            bestStar.enabled = true;
        }
        fillLevel.fillAmount = Mathf.Lerp(fillLevel.fillAmount, (float)levelD / 18, 3f * Time.deltaTime);
        if (levelD == 18)
        {
            bestLevel.enabled = true;
        }
    }
}
