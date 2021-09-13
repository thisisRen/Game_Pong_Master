using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DATA LEVEL", menuName = "NgaPham/DATA2")]

public class DATALEVEL : ScriptableObject
{
    public List<Level> listLevel;

    public void LoadData()
    {
        string LevelPlay = "";
        if (PlayerPrefs.GetInt("LevelIsStart") == 0)
        {
            LevelPlay = "1";
            for (int i = 1; i < listLevel.Count; i++)
            {
                LevelPlay += "0";
            }
            PlayerPrefs.SetInt("LevelIsStart", 1);
        }
        else
        {
            LevelPlay = PlayerPrefs.GetString("LevelChoose");
        }

        for (int i = 0; i < listLevel.Count; i++)
        {
            listLevel[i].isPlay = LevelPlay[i] == '0' ? false : true;
        }
    }
    public void SaveData() //luu data
    {
        string LevelPlay = "";
        for (int i = 0; i < listLevel.Count; i++)
        {
            LevelPlay += listLevel[i].isPlay ? "1" : "0";
        }
        PlayerPrefs.SetString("LevelChoose", LevelPlay);
    }

    public int FindIndexListChoose()
    {
        for (int i = 0; i < listLevel.Count; i++)
        {
            if (listLevel[i].isPlay) return i;
        }
        return 0;
    }
    public void Refresh(int index)
    {
        foreach (Level element in listLevel)
        {
            element.isPlay = false;
        }
        listLevel[index].isPlay = true;
    }
}

    [System.Serializable]
    public class Level
    {
        public int ID;
        public string name;
        public GameObject gamePlay;
        public bool isPlay;
        public int stars;
    }

