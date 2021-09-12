using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BallElement : MonoBehaviour
{
    public static BallElement Instance;

    private Ball data;

    public DATA_BALL model;

    public Image avatar;

    public Button elementBall;

    public Image done;

    public Sprite notDone, isDone;

    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if (data.IsBuy == true && data.IsChoose == false)
        {
            done.enabled = false;
        }
    }
    public void SetData(Ball _data) 
    {
        data = _data;
        avatar.sprite = data.avatar;
        if (data.IsBuy == false)
        {
            done.enabled = true;
            elementBall.image.color = Color.gray;
            done.sprite = notDone;
        }
        else if (data.IsBuy == true && data.IsChoose == false)
        {
            elementBall.image.color = Color.white;
            done.enabled = false;
        }
        else if (data.IsBuy == true && data.IsChoose == true)
        {
            done.enabled = true;
            elementBall.image.color = Color.white;
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
