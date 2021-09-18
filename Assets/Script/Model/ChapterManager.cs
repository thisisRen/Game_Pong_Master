using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterManager : MonoBehaviour
{
    public DATALEVEL level;
    public GameObject parentLevel, menu;
    void Start()
    {
        parentLevel.GetComponent<ShowUILevel>().ShowLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Home()
    {
        level.SaveData();
        gameObject.SetActive(false);
        menu.SetActive(true);
    }
}
