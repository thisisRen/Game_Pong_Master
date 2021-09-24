using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GamePongMaster
{
    public delegate void GamePlayEvent();
    public static GamePlayEvent Win;
    public static GamePlayEvent Lose;
    public static GamePlayEvent Play;

    public delegate void GameManagerEvent();
    public static GameManagerEvent Music;
    public static GameManagerEvent Sound;
  
}
