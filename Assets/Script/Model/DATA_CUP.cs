using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DATACUP", menuName = "NgaPham/DATA1")]
public class DATA_CUP : ScriptableObject
{
    public List<Cup> StoreCup;

    public void LoadData()
    {
        string StoreChoose = "";
        string StoreBuy = "";
        if (PlayerPrefs.GetInt("IsStart") == 0)
        {
            StoreBuy = "1";
            StoreChoose = "1";
            for (int i = 1; i < StoreCup.Count; i++)
            {
                StoreBuy += "0";
                StoreChoose += "0";
            }
            PlayerPrefs.SetInt("IsStart", 1);
        }
        else
        {
            StoreBuy = PlayerPrefs.GetString("StoreBuy");
            StoreChoose = PlayerPrefs.GetString("StoreChoose");
        }

        for (int i = 0; i < StoreCup.Count; i++)
        {
            StoreCup[i].IsBuy = StoreBuy[i] == '0' ? false : true;
            StoreCup[i].IsChoose = StoreChoose[i] == '0' ? false : true;
        }
    }
    public void SaveData() //luu data
    {
        string StoreChoose = "";
        string StoreBuy = "";
        for (int i = 0; i < StoreCup.Count; i++)
        {
            StoreChoose += StoreCup[i].IsChoose ? "1" : "0";
            StoreBuy += StoreCup[i].IsBuy ? "1" : "0";
        }
        PlayerPrefs.SetString("StoreBuy", StoreBuy);
        PlayerPrefs.SetString("StoreChoose", StoreChoose);
    }

    public int FindIndexStoreChoose()  // tim character da duoc chon
    {
        for (int i = 0; i < StoreCup.Count; i++)
        {
            if (StoreCup[i].IsChoose) return i;
        }
        return 0;
    }
    public void Refresh(int index)  // xet cac character khong duoc chon ve khong duoc chon
    {
        foreach (Cup element in StoreCup)
        {
            element.IsChoose = false;
        }
        StoreCup[index].IsChoose = true;
    }
}

[System.Serializable]
public class Cup
{
    public int ID;
    public string name;
    public Sprite avatar;

    public int Price;

    public bool IsBuy;
    public bool IsChoose;
}