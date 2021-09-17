using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIMove : MonoBehaviour
{
    [SerializeField] private RectTransform react;
    public float newPos;
    public float time;

    private void Start()
    {
        Turn();
    }
    public void Turn()
    {
        react.DOAnchorPosX(newPos, time).OnComplete(() =>
        {
            react.DOKill();
        });
    }
}