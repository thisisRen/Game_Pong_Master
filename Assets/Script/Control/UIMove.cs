using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public abstract class UIMove : MonoBehaviour
{
    [SerializeField] private RectTransform reactLeft;
    [SerializeField] private RectTransform reactRight;

    public virtual void TurnLeft()
    {
        
    }
}
