using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpawnCoin : MonoBehaviour
{
    [SerializeField] GameObject animationCoinPrefab;
    [SerializeField] RectTransform target,parent;

    [Header("Coin to pool")]
    [SerializeField] int maxCoin;

    Queue<GameObject> coinsQueue = new Queue<GameObject>();

    [Header("Animation Setting")]
    [SerializeField] [Range(0.5f, 0.9f)] float minAnimationDurarion;
    [SerializeField] [Range(0.9f, 2f)] float maxAnimationDurarion;
    [SerializeField] Ease easeType;

    Vector3 targerPos;
    private int _c = 0;

    private void Awake()
    {
        targerPos = target.position;
        PrepareCoin();
    }

    public int Coin
    {
        get {
            return _c;
        }
        set{
            _c = value;
            
        }
    }
    void PrepareCoin()
    {
        GameObject coin;
        for(int i=0; i<maxCoin; i++)
        {
            coin = Instantiate(animationCoinPrefab, Vector3.zero, Quaternion.identity);
            coin.GetComponent<RectTransform>().SetParent(parent);
            coin.transform.localScale = Vector3.one;
            coin.SetActive(false);
            coinsQueue.Enqueue(coin);
        }
        
    }
    void Animate( int amount)
    {
        for(int i=0; i< amount; i++)
        {
            if(coinsQueue.Count > 0)
            {
                GameObject coin = coinsQueue.Dequeue();
                coin.SetActive(true);
                coin.transform.SetParent(parent);

                float duaration = Random.Range(minAnimationDurarion, maxAnimationDurarion);
                coin.GetComponent<RectTransform>().DOMove(targerPos, duaration)
                    .SetEase(easeType)
                    .OnComplete(() =>
                    {
                        coin.SetActive(false);
                        coinsQueue.Enqueue(coin);

                        Coin++;
                    });

            }
        }
    }
    public void AddCoins( int amount)
    {
        Animate(amount);
    }
}
