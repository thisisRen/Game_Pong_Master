using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGamePlay : MonoBehaviour
{
    public static LoadGamePlay Instance;

    public DATALEVEL level;
    public GameObject gamePlay;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        LoadGame();

    }
    private void Update()
    {
        
    }
    public void LoadGame()
    {
        if (level.listLevel[level.FindIndexListChoosing()].current == true)
        {

            gamePlay = Instantiate(level.listLevel[level.FindIndexListChoosing()].gamePlay);

        }


    }
}
