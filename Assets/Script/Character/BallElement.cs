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

    public Sprite isDone;

    private static int idBall;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        StoreManager.Instance.useButtonText.text = "USING";
        StoreManager.Instance.useButton.GetComponent<Image>().sprite = StoreManager.Instance.bought;
        StoreManager.Instance.coinInButton.enabled = false;
    }
    private void Update()
    {
        if (data.current == false)
        {
            done.enabled = false;
        }
        if(data.IsBuy == true)
        {
            elementBall.image.color = Color.white;
        }
        ButtonBuy();
    }
    public void SetData(Ball _data) 
    {
        data = _data;
        avatar.sprite = data.avatar;
        if (data.IsBuy == false)
        {
            data.current = false;
            done.enabled = false;
            elementBall.image.color = Color.gray;
        }
        else if (data.IsBuy == true && data.IsChoose == false)
        {
            data.current = false;
            elementBall.image.color = Color.white;
            done.enabled = false;
        }
        else if (data.IsBuy == true && data.IsChoose == true)
        {
            data.current = true;
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
        data.current = true;
        ButtonBuy();
        model.Clean(data.ID);
        done.enabled = true; done.sprite = isDone;
        idBall = data.ID;

        Debug.Log(idBall);
    }
    public int AvatarCurrent()
    {
        return idBall;
    }
    public void ButtonBuy()
    {
        if (data.current == true)
        {
            if (data.IsBuy == true && data.IsChoose == false)
            {
                StoreManager.Instance.useButtonText.text = "USE";
                StoreManager.Instance.useButton.GetComponent<Image>().sprite = StoreManager.Instance.bought;
                StoreManager.Instance.coinInButton.enabled = false;
            }
            else if (data.IsBuy == true && data.IsChoose == true)
            {
                StoreManager.Instance.useButtonText.text = "USING";
                StoreManager.Instance.useButton.GetComponent<Image>().sprite = StoreManager.Instance.bought;
                StoreManager.Instance.coinInButton.enabled = false;
            }
            else
            {
                StoreManager.Instance.useButtonText.text = data.Price.ToString();
                StoreManager.Instance.useButton.GetComponent<Image>().sprite = StoreManager.Instance.buy;
                StoreManager.Instance.coinInButton.enabled = true;
            }
        }
    }
}
