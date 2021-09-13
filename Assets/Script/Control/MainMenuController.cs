using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject store, mainMenu, chapter;
    public DATA_CUP cup;
    public DATA_BALL ball;
    public DATALEVEL level;
    void Start()
    {
        cup.LoadData();
       // ball.LoadData();
        //level.LoadData();
    }

    public void ShowStore()
    {
        mainMenu.SetActive(false);
        store.SetActive(true);

    }
    public void Chapter()
    {
        mainMenu.SetActive(false);
        chapter.SetActive(true);
    }
    
   
}
