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

    public Sprite isDone;

    private static int idCup;

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
            elementCup.image.color = Color.white;
        }
        ButtonBuy();
    }
    public void SetData(Cup _data) //show 1 cup in store when start
    {
        data = _data;
        avatar.sprite = data.avatar;
        if (data.IsBuy == false)
        {
            data.current = false;
            done.enabled = false;
            elementCup.image.color = Color.gray;
        }
        else if(data.IsBuy == true && data.IsChoose == false)
        {
            data.current = false;
            elementCup.image.color = Color.white;
            done.enabled = false;
        }
        else if (data.IsBuy == true && data.IsChoose == true)
        {
            data.current = true;
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
        data.current = true;
        ButtonBuy();
        model.Clean(data.ID);
        done.enabled = true; done.sprite = isDone;
        idCup = data.ID;
    }
    public int AvatarCurrent()
    {
        return idCup;
    }
    public void ButtonBuy()
    {
        if(data.current == true)
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
