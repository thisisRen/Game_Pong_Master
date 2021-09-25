using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
public class GameManager : MonoBehaviour
{
    #region Singleton class: GameManager
    public static GameManager Instance;

    private void Awake()
    {
        if(Instance != null)
        {
            Instance = this;
        }
    }
    #endregion

    Camera cam;
    public BallControl ball;
    public Trajectory trajectory;
    [SerializeField] float pushForce = 4f;
    bool isDragging = false;
    Vector2 startPoins;
    Vector2 endPoins;
    Vector2 direction;
    Vector2 force;
    float distance;
    public static int numberBallUse;
    private int index;
    private Vector2 currentTransform;

    public static int done = 0;

    public float timeToWait;

    private void Start()
    {
        cam = Camera.main;
        ball.DeactivateRb();

        numberBallUse = 0;
        index = 0;

        currentTransform = ball.transform.position;

        done = 0;

        GamePongMaster.Play += Play;

    }
    private void Update()
    {
    
        GamePongMaster.Play?.Invoke();
        if(GameController.Instance.modeGame == ModeGame.Mode.BEER)
        {
            if (done == GameController.Instance.numCup)
            {
                GamePongMaster.Play -= Play;
                GamePongMaster.Win?.Invoke();
               

            }
        }
        else if (GameController.Instance.modeGame == ModeGame.Mode.STAR)
        {
            if (done == GameController.Instance.numStar)
            {
                GamePongMaster.Play -= Play;
                GamePongMaster.Win?.Invoke();
               
            }
        }

    }
    private void OnDestroy()
    {
        GamePongMaster.Play -= Play;
    }
    public void Play()
    {
        if (Input.GetMouseButtonDown(0) && !IsMouseOverUI() && Time.timeScale != 0)
        {
            isDragging = true;
            OnDragStart();
        }
        if (Input.GetMouseButtonUp(0) && !IsMouseOverUI() && Time.timeScale != 0)
        {
            isDragging = false;
            OnDragEnd();
            StartCoroutine(GetNewBall(0.5f));
            LevelUIManager.Instance.BallGray();

            FindObjectOfType<AudioManager>().PlayEffect("Ball");
        }
        if (isDragging && !IsMouseOverUI())
        {
            OnDrag();
        }
    }

    void OnDragStart()
    {
      
        ball.DeactivateRb();
        startPoins = cam.ScreenToWorldPoint(Input.mousePosition);
        trajectory.Show();
        
    }
    void OnDrag()
    {
        if (!IsMouseOverUI())
        {
            endPoins = cam.ScreenToWorldPoint(Input.mousePosition);
            distance = Vector2.Distance(startPoins, endPoins);
            direction = (startPoins - endPoins).normalized;
            force = direction * distance * pushForce;

            Debug.DrawLine(startPoins, endPoins);

            trajectory.UpdateDots(ball.pos, force);
        }
    }
    void OnDragEnd()
    {

        ball.ActivateRb();
        ball.Push(force);

        trajectory.Hide();
        numberBallUse += 1;

        //set lose
        if(GameController.Instance.modeGame == ModeGame.Mode.BEER)
        {
            if (numberBallUse == GameController.Instance.numberBall && done < GameController.Instance.numCup )
            {
                GamePongMaster.Play -= Play;
                StartCoroutine(SetLoseWhenUseFullBallCup(timeToWait));

            }
        }
        else
        {
            if (numberBallUse == GameController.Instance.numberBall && done < GameController.Instance.numStar)
            {
                
                GamePongMaster.Play -= Play;
                StartCoroutine(SetLoseWhenUseFullBallStar(timeToWait));

            }
        }
        
    }
    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    private IEnumerator GetNewBall(float waitTime)
    {
        if ((GameController.Instance.numberBall - 1) - numberBallUse >= 0 && numberBallUse != 0)
        {
            yield return new WaitForSeconds(waitTime);
            ObjectPooler.Instance.ballList[index].transform.position = currentTransform;
            ObjectPooler.Instance.ballList[index].GetComponent<BallControl>().DeactivateRb();

            ObjectPooler.Instance.ballList[index].SetActive(true);
            ball = ObjectPooler.Instance.ballList[index].GetComponent<BallControl>();
            index++;


        }
        
        
    }
    public static int TargetDone()
    {
        return done;
    }
    public static int NumberBallUse()
    {
        return numberBallUse;
    }

    private IEnumerator SetLoseWhenUseFullBallCup(float time)
    {
        if(GameController.Instance.modeGame == ModeGame.Mode.BEER)
        {
            yield return new WaitForSeconds(time);

            if ((BallControl.ballIncup == true && done == GameController.Instance.numCup))
            {

                GamePongMaster.Win.Invoke();
                
            }
            else
            {
                GamePongMaster.Lose.Invoke();
            }
        }
        
    }
    private IEnumerator SetLoseWhenUseFullBallStar(float time)
    {
        if (GameController.Instance.modeGame == ModeGame.Mode.STAR)
        {
            yield return new WaitForSeconds(time);

            if (done == GameController.Instance.numStar)
            {
                GamePongMaster.Win.Invoke();
               
            }
            else
            {
                GamePongMaster.Lose.Invoke();
            }
        }
        
    }
}
 