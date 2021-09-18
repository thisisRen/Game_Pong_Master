using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelUIManager : MonoBehaviour
{
    public static LevelUIManager Instance;

    [Header("UI")]
    public GameObject pausePopup;

    public Text target, targetDone;

    public Image imageTarget;

    public Sprite cup, star, glass;

    public Text modeGameText;

    public GameObject ball;

    public RectTransform groupBallUI;

    [Header("POPUP")] public GameObject popupComplete;
    [Header("POPUP")] public GameObject popupGameOver;

    [Header("Background")]
    public GameObject backgroundGame;

    public List<Sprite> background;

    private int t;

    private List<GameObject> ballUI;
    public int currentBall;

    private void Awake()
    {
        Instance = this;

        GamePongMaster.Win += CompletedGame;
        GamePongMaster.Lose += GameOver;
    }
    void Start()
    {
        t = Random.Range(0, background.Count);
        backgroundGame.GetComponent<Transform>().localScale = new Vector3(0.5f, 0.8f, 1f);
        backgroundGame.GetComponent<SpriteRenderer>().sprite = background[t];

        ballUI = new List<GameObject>();
        currentBall = 0;

        ShowUI();
        SpawnBallUI();

     


    }

    // Update is called once per frame
    void Update()
    {
        UpdateTarget();


    }
    public void PlayAgain()
    {
        GamePongMaster.Win -= CompletedGame;
        GamePongMaster.Lose -= GameOver;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        pausePopup.SetActive(true);
    }
    public void Continue()
    {
        Time.timeScale = 1f;
        pausePopup.SetActive(false);
    }
    public void Home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    private void ShowUI()
    {
        if ( GameController.Instance.modeGame == ModeGame.Mode.BEER)
        {
            imageTarget.sprite = cup;
            target.text = GameController.Instance.numCup.ToString();
            modeGameText.text = "Pong Beer Game";

        }
        else if(GameController.Instance.modeGame == ModeGame.Mode.STAR)
        {
            imageTarget.sprite = star;
            target.text = GameController.Instance.numStar.ToString();
            modeGameText.text = "Pong Star Game";
        }
        else
        {
            imageTarget.sprite = glass;
            target.text = GameController.Instance.numGlass.ToString();
            modeGameText.text = "Pong Break Game";
        }
        
    }
    public void SpawnBallUI()
    {
   
        for(int i=0; i<GameController.Instance.numberBall; i++)
        {
            GameObject b = Instantiate(ball, Vector3.zero, Quaternion.identity);
            b.GetComponent<RectTransform>().SetParent(groupBallUI);
            ballUI.Add(b);
        }
    }
    public void BallGray()
    {
        if(GameManager.numberBallUse != 0)
        {
            for (int i = 0; i < GameController.Instance.numberBall; i++)
            {
                if (i == currentBall)
                    ballUI[i].GetComponent<Image>().color = Color.gray;
            }
            currentBall++;

            Debug.Log(currentBall);
        }
        
    }
    public void UpdateTarget()
    {
        targetDone.text = GameManager.TargetDone().ToString();
    }


    private IEnumerator PopupComplete()
    {
        yield return new WaitForSeconds(2f);
        

        popupComplete.SetActive(true);
    }

    private IEnumerator PopupGameOver()
    {
        yield return new WaitForSeconds(5f);
       
        popupGameOver.SetActive(true);
    }
    
    private void CompletedGame()
    {
        GamePongMaster.Lose -= GameOver;
        StartCoroutine(PopupComplete());
    }
    private void GameOver()
    {
        GamePongMaster.Win -= CompletedGame;
        StartCoroutine(PopupGameOver());
    }

}
