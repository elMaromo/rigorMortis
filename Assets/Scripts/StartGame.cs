using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class StartGame : MonoBehaviour
{
    //public GameObject dialogueManaguer;
    //public PlayerEnter playerEnter;
    
    public UnityEngine.UI.Image StartGameImage;
    public UnityEngine.UI.Image Background;
    public float timeToStartGame;

    private DialogueLobby dialogueLobby;
    private float timerStartingGame;
    private bool StartingGame;

    public void Awake()
    {
        dialogueLobby = GetComponent<DialogueLobby>();
    }

    public void Start()
    {
        timerStartingGame = 0;
        StartingGame = false;
    }

    public void Update()
    {
        if (StartingGame)
        {
            timerStartingGame += Time.deltaTime;
            float nextAlpha = 1 - timerStartingGame/timeToStartGame;

            Color tempColor = StartGameImage.color;
            tempColor.a = nextAlpha;
            StartGameImage.color = tempColor;
            tempColor = Background.color;
            tempColor.a = nextAlpha;
            Background.color = tempColor;

            if( timerStartingGame > timeToStartGame )
            {
                //dialogueManaguer.SetActive(true);
                //playerEnter.enabled = true;
                dialogueLobby.enabled = true;
                //Destroy(gameObject);
            }
        }
    }

    public void StartGameButtonPressed()
    {
        StartingGame = true;
    }
}
