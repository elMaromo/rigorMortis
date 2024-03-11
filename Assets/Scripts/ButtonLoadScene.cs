using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLoadScene : MonoBehaviour
{
    public string nameOfScene;
    public void LoadSceneOnClick()
    {   
        SceneManager.LoadScene(nameOfScene);
    }
}
