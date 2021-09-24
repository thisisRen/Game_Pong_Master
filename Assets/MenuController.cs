using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public static MenuController Instance;
    public GameObject menu, chapters;
    private void Awake()
    {
        Instance = this; 

    }
    public void Menu()
    {
        chapters.SetActive(false);
        menu.SetActive(true);
    }
    public void Chapters()
    {
        menu.SetActive(false);
        chapters.SetActive(true);
    }
}
