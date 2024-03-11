using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueLobby : MonoBehaviour
{
    public GameObject textDialogue;
    public Transform placeOfDialogues;
    public List<string> dialogues;
    public float timeBetweenDialogues;

    public GameObject dialogueManaguer;
    public PlayerEnter playerEnter;

    private float timerDialogue;
    private int indexDialogue;
    private AudioSource audioPlayer;


    public void Awake()
    {
        audioPlayer = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        timerDialogue = 1;
        indexDialogue = 0;
    }

    // Update is called once per frame
    void Update()
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
                dialogueManaguer.SetActive(true);
                playerEnter.enabled = true;
                Destroy(gameObject);
            }
        }
    }
}
