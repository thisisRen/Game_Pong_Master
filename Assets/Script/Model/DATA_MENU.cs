using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DATAMENU", menuName = "NgaPham/DATA3")]
public class DATA_MENU : ScriptableObject
{
    public List<SoundGame> Sound;

    public void SaveData() //luu data
    {
        string onSound = "";
        
        for (int i = 0; i < Sound.Count; i++)
        {
            onSound += Sound[i].onSound ? "1" : "0";
         
        }
        PlayerPrefs.SetString("onSound", onSound);
    }
}
[System.Serializable]
public class SoundGame
{
    public string name;
    public bool onSound;
}