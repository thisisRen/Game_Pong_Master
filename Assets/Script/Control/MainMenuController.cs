using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject store, mainMenu;
    public DATA_CUP cup;
    void Start()
    {
        
    }

    public void ShowStore()
    {
        cup.LoadData();
        mainMenu.SetActive(false);
        store.SetActive(true);

    }
    
   
}
