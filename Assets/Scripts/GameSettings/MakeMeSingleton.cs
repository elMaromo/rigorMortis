using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeMeSingleton : MonoBehaviour
{
    public static MakeMeSingleton Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
