using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DATA Game Play", menuName = "NgaPham/DATA Game Play")]
public class DATA_GamePlay : ScriptableObject
{
    public List<Level> levelList;

    [System.Serializable]
    public class Level
    {
        public int ID;
        public GameObject prefabs;
        public bool isPlay;
        public bool isWin;

    }
}
