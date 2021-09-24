using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class CompleteGame : MonoBehaviour
{
    public DATALEVEL data;
    public Image[] star;
    public GameObject[] starCollect;
    public Sprite starCompleted;
    public Text level;
    public SpawnCoin spawnCoin;
    public ParticleSystem starCollectUI;
    [SerializeField] GameObject coinPrefabs;

    public Text addCoin;
    public Text myCoin;

    private static int coin = 0;

    void Start()
    {
        
        int t = data.listLevel[data.FindIndexListChoosing()].ID + 1;
        level.text = "LEVEL " + t.ToString();

        FindObjectOfType<AudioManager>().PlayMusic("Complete");
        LevelUIManager.Instance.PlayCannon();
        NumberStar();
        StartCoroutine(CollectStar());
        StartCoroutine(SpawnCoin());
        

    }

    // Update is called once per frame
    void Update()
    {
        SetStarLevel();
        if(data.listLevel[data.FindIndexListChoosing()].stars > 0)
        {
            data.listLevel[data.FindIndexListChoosing()+1].isPlay = true;
        }
        
    }
    private int NumberStar()
    {
        if(GameController.Instance.modeGame == ModeGame.Mode.BEER)
        {
            if (GameManager.NumberBallUse() == GameController.Instance.numCup)
            {
                return 3;
            }
            else if (GameManager.NumberBallUse() > GameController.Instance.numCup && GameManager.NumberBallUse() < GameController.Instance.numberBall)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }

        else 
        {
            if (GameManager.NumberBallUse() == 1 && GameManager.done == GameController.Instance.numStar)
            {
                return 3;
            }
            else if (GameManager.NumberBallUse() > 1 && GameManager.NumberBallUse() < GameController.Instance.numberBall && GameManager.done == GameController.Instance.numStar)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }

        

    }
    private void SetStarLevel()
    {
        if(NumberStar() > data.listLevel[data.FindIndexListChoosing()].stars)
        {
            data.listLevel[data.FindIndexListChoosing()].stars = NumberStar();
            
        }
    }
    public void NextLevel()
    {

        if ( data.FindIndexListChoosing() + 1 < data.listLevel.Count && data.listLevel[data.FindIndexListChoosing() + 1].isPlay == false )
        {
          
            
            PlayerPrefs.SetInt("MaxLevel", data.FindIndexListChoosing() + 1);
            data.listLevel[data.FindIndexListChoosing() + 1].current = true;
            data.Refresh(data.FindIndexListChoosing() + 1);
            SceneManager.LoadScene(1);
            
        }
        else if (data.FindIndexListChoosing() + 1 < data.listLevel.Count && data.listLevel[data.FindIndexListChoosing() + 1].isPlay == true )
        {
            
            data.Refresh(data.FindIndexListChoosing() + 1);
            SceneManager.LoadScene(1);

            //Debug.Log(data.FindIndexListChoosing() + 1);
        }

        else 
        {
            
            SceneManager.LoadScene(0);
            
        }

    }
    public void Home()
    {
        SceneManager.LoadScene(0);
    }
    private IEnumerator SpawnCoin()
    {
        yield return new WaitForSeconds(0.3f);
        if(data.listLevel[data.FindIndexListChoosing()].coin == 15)
        {
            if(NumberStar() == 3)
            {
                spawnCoin.AddCoins(15);
                data.listLevel[data.FindIndexListChoosing()].coin -= 15;
                addCoin.text = "+15";
                coin += 15;
                PlayerPrefs.SetInt("Coin", coin);
                Destroy(Instantiate(coinPrefabs, Vector3.zero, Quaternion.identity));
            }
            else if (NumberStar() == 2)
            {
                spawnCoin.AddCoins(10);
                data.listLevel[data.FindIndexListChoosing()].coin -= 10;
                addCoin.text = "+10";
                coin += 10;
                PlayerPrefs.SetInt("Coin", coin);
                Destroy(Instantiate(coinPrefabs, Vector3.zero, Quaternion.identity));
            }
            else
            {
                spawnCoin.AddCoins(5);
                data.listLevel[data.FindIndexListChoosing()].coin -= 5;
                addCoin.text = "+5";
                coin += 5;
                PlayerPrefs.SetInt("Coin", coin);
                Destroy(Instantiate(coinPrefabs, Vector3.zero, Quaternion.identity));
            }
            
        }
        else
        {
            if (NumberStar() == 3)
            {

                spawnCoin.AddCoins(data.listLevel[data.FindIndexListChoosing()].coin);
                addCoin.text = "+" + data.listLevel[data.FindIndexListChoosing()].coin.ToString();
                coin += data.listLevel[data.FindIndexListChoosing()].coin;
                PlayerPrefs.SetInt("Coin", coin);
                data.listLevel[data.FindIndexListChoosing()].coin =0;
                Destroy(Instantiate(coinPrefabs, Vector3.zero, Quaternion.identity));
            }
            else
            {
                addCoin.text = "+0";
            }
        }
        myCoin.DOText(PlayerPrefs.GetInt("Coin").ToString(), 1f, true, ScrambleMode.None, null).OnComplete(() =>
        {
            myCoin.DOKill();
        });
        data.SaveData();
        
    }
    private IEnumerator CollectStar()
    {
        yield return new WaitForSeconds(0.1f);
        if (NumberStar() == 1)
        {
            starCollect[0].SetActive(true);
            starCollectUI.Play();
        }
        else if (NumberStar() == 2)
        {
            starCollect[0].SetActive(true);
            starCollectUI.Play();
            yield return new WaitForSeconds(0.5f);
            starCollect[1].SetActive(true);
            starCollectUI.Play();

        }
        else
        {
            starCollect[0].SetActive(true);
            starCollectUI.Play();
            yield return new WaitForSeconds(0.5f);
            starCollect[1].SetActive(true);
            starCollectUI.Play();
            yield return new WaitForSeconds(0.5f);
            starCollect[2].SetActive(true);
            starCollectUI.Play();


        }
    }
        
}
