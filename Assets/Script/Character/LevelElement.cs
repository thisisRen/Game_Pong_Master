using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelElement : MonoBehaviour
{
    public static LevelElement Instance;
    private Level data;
    public DATALEVEL model;

    public Text levelNumber;
    public Image lockLevel;
    public GameObject start;

    public Button elementLevel;

    public List<Image> star;
  
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
       
    }
    public void SetData(Level _data) 
    {
        data = _data;
        levelNumber.text = (data.ID+1).ToString();
        if(data.isPlay == false)
        {
            lockLevel.enabled = true;
            start.SetActive(false);
        }
        else if(data.isPlay == true && data.stars == 0)
        {
            lockLevel.enabled = false;
            start.SetActive(false);
        }
        else if(data.isPlay == true && data.stars != 0)
        {
            lockLevel.enabled = false;
            start.SetActive(true);
        }


        if(data.stars != 0)
        {
            for(int i=0; i< data.stars; i++)
            {
                star[i].GetComponent<Image>().enabled = true;
            }
        }
    }
    /// <summary>
    /// choose a level to play
    /// </summary>
    public void AvatarOnClicked()
    {
        if(data.isPlay == true)
        {
            data.current = true;
            model.Refresh(data.ID);
            SceneManager.LoadScene(1);
        }
        

    }
}
