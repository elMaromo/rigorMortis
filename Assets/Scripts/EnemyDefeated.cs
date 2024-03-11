using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyDefeated : MonoBehaviour
{
    public Transform pivotDeath;
    public float angle;
    public float timeRotation;
    public EnemyScript enemy;
    public SpriteRenderer sprit;

    private bool hasDied;
    private AudioSource audi;

    public void Awake()
    {
        audi = GetComponent<AudioSource>();
    }

    public void Start()
    {
        hasDied = false;
    }

    public void Update()
    {
        if (!hasDied)
        {
            if (enemy.health <= 0)
            {
                hasDied = true;
                audi.Play();
                sprit.enabled = true;
                Sequence mySequence = DOTween.Sequence();
                mySequence.Append(pivotDeath.DOLocalRotate(new Vector3(angle, 0, -angle/2), timeRotation));
            }
        }
    }
}
