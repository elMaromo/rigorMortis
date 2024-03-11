using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuActivator : MonoBehaviour
{
    public GameObject UIPauseMenu;
    private bool isActivated;

    void Start()
    {
        isActivated = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isActivated = !isActivated;
            UIPauseMenu.SetActive(!UIPauseMenu.activeSelf);
        }
    }
}
