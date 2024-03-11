using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnColision : MonoBehaviour
{
    public string nextSceneName;
    public Transform playerTr;

    public void Update()
    {
        float distance = Vector3.Distance(playerTr.position, transform.position);
        if (distance < 3)
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
