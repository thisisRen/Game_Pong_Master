using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterManager : MonoBehaviour
{
    public DATALEVEL level;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Home()
    {
        level.SaveData();
        gameObject.SetActive(false);
    }
}
