using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadOfPlayer : MonoBehaviour
{
    public string nameOfSceneToReset;

    private PlayerScript plyScrpt;

    public void Awake()
    {
        plyScrpt = GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (plyScrpt.health <= 0)
        {
            SceneManager.LoadScene(nameOfSceneToReset);
        }
    }
}
