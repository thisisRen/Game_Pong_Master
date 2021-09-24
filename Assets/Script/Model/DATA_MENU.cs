using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DATAMENU", menuName = "NgaPham/DATA3")]
public class DATA_MENU : ScriptableObject
{
    public List<SoundGame> Sound;
    public List<Popups> Popups;

    public void SaveData() //luu data
    {
        string onSound = "";
        
        for (int i = 0; i < Sound.Count; i++)
        {
            onSound += Sound[i].onSound ? "1" : "0";
         
        }
        PlayerPrefs.SetString("onSound", onSound);
    }

    public void SaveDataMenu() //luu data
    {
        string active = "";

        for (int i = 0; i < Popups.Count; i++)
        {
            active += Popups[i].active ? "1" : "0";

        }
        PlayerPrefs.SetString("onSound", active);
    }

}
[System.Serializable]
public class SoundGame
{
    public string name;
    public bool onSound;
}
[System.Serializable] 
public class Popups
{
    public string name;
    public bool active;
}