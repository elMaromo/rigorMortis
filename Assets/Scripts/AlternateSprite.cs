using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternateSprite : MonoBehaviour
{
    public Sprite newSprit;
    public float timeToChange;

    private SpriteRenderer sprRn;
    private Sprite originalSpr;
    private float timerChange;
    private bool changed;

    public void Awake()
    {
        sprRn = GetComponent<SpriteRenderer>();
        timerChange = 0;
        changed = false;
    }

    public void Start()
    {
        originalSpr = sprRn.sprite;
        timerChange = 0;
        changed = false;
    }

    public void Update()
    {
        timerChange += Time.deltaTime;
        if (timerChange > timeToChange)
        {
            timerChange = 0;

            if (changed)
            {
                sprRn.sprite = originalSpr;
            }
            else
            {
                sprRn.sprite = newSprit;
            }

            changed = !changed;
        }
    }
}
