using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictorWin : MonoBehaviour
{
    private EnemyScript enemyScr;
    public string nextSceneToBeLoaded;

    public void Awake()
    {
        enemyScr = GetComponent<EnemyScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if( enemyScr.health <= 0 )
        {
            SceneManager.LoadScene(nextSceneToBeLoaded);
        }
    }
}
