using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitFrameRate : MonoBehaviour
{
    public int targetFrameRate = 144;

    private void Awake()
    {
        LimitFPS();
    }

    private void LimitFPS()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFrameRate;
    }
}
