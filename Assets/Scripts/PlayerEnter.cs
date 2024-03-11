using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerEnter : MonoBehaviour
{
    public Transform posPlayer;
    public float timeToEnter;

    // Start is called before the first frame update
    void Start()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOMove(posPlayer.position, timeToEnter));
    }

}
