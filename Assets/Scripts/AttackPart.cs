using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPart : MonoBehaviour
{
    public bool readyToAttack;
    public bool hasClicked;

    public void Start()
    {
        readyToAttack = false;
        hasClicked = false;
    }

    void OnMouseDown()
    {
        if (readyToAttack)
        {
            hasClicked = true;
        }
    }
}
