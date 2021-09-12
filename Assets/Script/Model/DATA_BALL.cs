using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DATABALL", menuName = "NgaPham/DATA")]
public class DATA_BALL : ScriptableObject
{
    public List<Ball> StoreBall;

    public void LoadData()
    {
        string StoreChoose = "";
        string StoreBuy = "";
        if (PlayerPrefs.GetInt("IsStart1") == 0)
        {
            StoreBuy = "1";
            StoreChoose = "1";
            for (int i = 1; i < StoreBall.Count; i++)
            {
                StoreBuy += "0";
                StoreChoose += "0";
            }
            PlayerPrefs.SetInt("IsStart1", 1);
        }
        else
        {
            StoreBuy = PlayerPrefs.GetString("StoreBuy1");
            StoreChoose = PlayerPrefs.GetString("StoreChoose1");
        }

        for (int i = 0; i < StoreBall.Count; i++)
        {
            StoreBall[i].IsBuy = StoreBuy[i] == '0' ? false : true;
            StoreBall[i].IsChoose = StoreChoose[i] == '0' ? false : true;
        }
    }
    public void SaveData() //luu data
    {
        string StoreChoose = "";
        string StoreBuy = "";
        for (int i = 0; i < StoreBall.Count; i++)
        {
            StoreChoose += StoreBall[i].IsChoose ? "1" : "0";
            StoreBuy += StoreBall[i].IsBuy ? "1" : "0";
        }
        PlayerPrefs.SetString("StoreBuy1", StoreBuy);
        PlayerPrefs.SetString("StoreChoose1", StoreChoose);
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
