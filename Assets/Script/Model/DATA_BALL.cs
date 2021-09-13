using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DATABALL", menuName = "NgaPham/DATA")]
public class DATA_BALL : ScriptableObject
{
    public List<Ball> StoreBall;

    public void LoadData()
    {
        string StoreChooseBall = "";
        string StoreBuyBall = "";
        if (PlayerPrefs.GetInt("IsStartBall") == 0)
        {
            StoreBuyBall = "1";
            StoreChooseBall = "1";
            for (int i = 1; i < StoreBall.Count; i++)
            {
                StoreBuyBall += "0";
                StoreChooseBall += "0";
            }
            PlayerPrefs.SetInt("IsStartBall", 1);
        }
        else
        {
            StoreBuyBall = PlayerPrefs.GetString("StoreBuyBall");
            StoreChooseBall = PlayerPrefs.GetString("StoreChooseBall");
        }

        for (int i = 0; i < StoreBall.Count; i++)
        {
            StoreBall[i].IsBuy = StoreBuyBall[i] == '0' ? false : true;
            StoreBall[i].IsChoose = StoreChooseBall[i] == '0' ? false : true;
        }

    }
    public void SaveData() //luu data
    {
        string StoreChooseBall = "";
        string StoreBuyBall = "";
        for (int i = 0; i < StoreBall.Count; i++)
        {
            StoreChooseBall += StoreBall[i].IsChoose ? "1" : "0";
            StoreBuyBall += StoreBall[i].IsBuy ? "1" : "0";
        }
        PlayerPrefs.SetString("StoreBuyBall", StoreBuyBall);
        PlayerPrefs.SetString("StoreChooseBall", StoreChooseBall);
    }

    public int FindIndexStoreChoose()  // tim character da duoc chon
    {
        for (int i = 0; i < StoreBall.Count; i++)
        {
            if (StoreBall[i].IsChoose) return i;
        }
        return 0;
    }
    public void Refresh(int index)  // xet cac character khong duoc chon ve khong duoc chon
    {
        foreach (Ball element in StoreBall)
        {
            element.IsChoose = false;
        }
        StoreBall[index].IsChoose = true;
    }
}

[System.Serializable]
public class Ball
{
    public int ID;
    public string name;
    public Sprite avatar;

    public int Price;

    public bool IsBuy;
    public bool IsChoose;
}
