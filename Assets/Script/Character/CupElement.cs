using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CupElement : MonoBehaviour
{
    public static CupElement Instance;

    private Cup data;

    public DATA_CUP model;

    public Image avatar;

    public Button elementCup;

    public Image done;

    public Sprite notDone, isDone;

    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if(data.IsBuy == true && data.IsChoose == false)
        {
            done.enabled = false;
        }
    }
    public void SetData(Cup _data) //show 1 cup in store
    {
        data = _data;
        avatar.sprite = data.avatar;
        if (data.IsBuy == false)
        {
            done.enabled = true;
            elementCup.image.color = Color.gray;
            done.sprite = notDone;
        }
        else if(data.IsBuy == true && data.IsChoose == false)
        {
            elementCup.image.color = Color.white;
            done.enabled = false;
        }
        else if (data.IsBuy == true && data.IsChoose == true)
        {
            done.enabled = true;
            elementCup.image.color = Color.white;
            done.sprite = isDone;
        }
    }
    /// <summary>
    /// choose a cup to play
    /// </summary>
    public void AvatarOnClicked() 
    {
        if (data.IsBuy == true)
        {
            data.IsChoose = true;
            done.enabled = true; done.sprite = isDone;
            model.Refresh(data.ID);
            model.SaveData();
        }
       

    }
    
    
}
