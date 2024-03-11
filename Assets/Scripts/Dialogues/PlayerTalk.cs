using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTalk : MonoBehaviour
{
    public GameObject textDialogue;
    public Transform placeOfDialogues;
    public List<string> dialogues;
    public float timeBetweenDialogues;
    public string nextSceneName;

    private float timerDialogue;
    private int indexDialogue;
    private bool finishedTalking;
    private AudioSource audioPlayer;

    public void Awake()
    {
        audioPlayer = GetComponent<AudioSource>();
    }


    
    // Start is called before the first frame update
    void Start()
    {
        finishedTalking = false;
        timerDialogue = 1;
        indexDialogue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!finishedTalking)
        {
            timerDialogue += Time.deltaTime;
            if (timerDialogue > timeBetweenDialogues)
            {
                audioPlayer.Play();
                timerDialogue = 0;
                GameObject newDialogue = Instantiate(textDialogue, placeOfDialogues);
                newDialogue.GetComponent<ChangeDialogue>().ChangeText(dialogues[indexDialogue]);
                indexDialogue++;
                if (indexDialogue >= dialogues.Count)
                {
                    finishedTalking = true;
                    Invoke("LoadNextSceneAfterDialogues", 3f);
                }
            }
        }
    }

    public void LoadNextSceneAfterDialogues()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
