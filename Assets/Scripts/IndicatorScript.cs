using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class IndicatorScript : MonoBehaviour
{
    public float offset;
    public float time;

    public void Start()
    {   
        Vector3 initPos = transform.position;
        Vector3 pos1 = initPos;
        Vector3 pos2 = initPos;
        pos1.y += offset;
        pos2.y -= offset;

        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOMove(pos1, time).SetEase(Ease.Flash));
        mySequence.Append(transform.DOMove(pos1, time).SetEase(Ease.Flash));
        mySequence.SetLoops(1000);
    }
}
