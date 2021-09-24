using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChapterMenuElement : MonoBehaviour
{
    public Text numberLevel;
    public int minID, maxID;
    public DATALEVEL level;
    public GameObject chapterMenu, chapters;
    public bool canPlay = false;
    public float next;
    void Start()
    {
        numberLevel.text = NumberStar().ToString() + "/27";
    }
    void Update()
    {
        
    }
    private int NumberStar()
    {
        int t = 0;
        for(int i=minID; i <= maxID; i++)
        {
            t += level.listLevel[i].stars;
        }
        return t;
    }
    public void AvatarOnClick()
    {
        if (canPlay == true)
        {
            chapterMenu.SetActive(false);
            chapters.SetActive(true);
            for(int i=0; i<next; i++)
            {
                ChapterManager.Instance.Right();
            }
            
        }
    }
}
