using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : ModeGame
{
    public static GameController Instance;

    public Mode modeGame;
    public int numberBall;
    public GameObject ballPrefabs;
    public GameObject ballCurrent;

    [Header("Mode Beer")]
    public int numCup;

    [Header("Mode Star")]
    public int numStar;

    [Header("Mode Break")]
    public int numGlass;

    private void Awake()
    {
        Instance = this;
    }
    private void FixedUpdate()
    {
       
    }



}
