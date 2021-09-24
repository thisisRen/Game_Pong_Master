using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChapterMenuController : MonoBehaviour
{
    public static ChapterMenuController Instance;
    public Sprite doneChapter;
    public List<ChapterMenuElement> chapter;
    private int index = 0;
    public GameObject menu;

    private void Awake()
    {
        Instance = this;
        
    }
    void Update()
    {
      
        int t = PlayerPrefs.GetInt("MaxLevel")+1;
        if(t% 10 == 0)
        {
            chapter[index].GetComponent<Image>().sprite = doneChapter;
            chapter[index].canPlay = true;
            

            if (index < chapter.Count-1) index++;
        }
    }
    public void Home()
    {
        gameObject.SetActive(false);
        menu.SetActive(true);
    }
    

}
