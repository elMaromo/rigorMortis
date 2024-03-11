using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public int health;
    public int atack;
    public float timeToAtack;
    public EnemyScript enemy;
    public Image healthBar;

    private float timerAtack;
    private bool enemyDeath;

    //dialogues
    public GameObject DialogueLine;
    public List<string> attackDialogues;
    public Transform placeOfDialogues;

    //attaack
    public List<AttackPart> parts;
    private bool readyToAttak;
    private int partToAttackNextIndex;
    private Vector3 originalScaleOfParts;
    private int maxHealth;
    private AudioSource audioPlayer;
    private int indexDialogueAttack;

    public void Awake()
    {
        audioPlayer = GetComponent<AudioSource>();
    }


    // Start is called before the first frame update
    public void Start()
    {
        indexDialogueAttack = 0;
        maxHealth = health;
        originalScaleOfParts = parts[0].transform.localScale;
        readyToAttak = false;
        enemyDeath = false;
        timerAtack = 0;
    }

    // Update is called once per frame
    public void Update()
    {
        healthBar.fillAmount = (float)health / (float)maxHealth;

        if (health <= 0)
        {
            print("playerMuerto");
        }

        if (!readyToAttak)
        {
            if (!enemyDeath)
            {
                timerAtack += Time.deltaTime;
                if (timerAtack > timeToAtack)
                {
                    readyToAttak = true;
                    partToAttackNextIndex = Random.Range(0, parts.Count);
                    parts[partToAttackNextIndex].readyToAttack = true;
                    parts[partToAttackNextIndex].transform.localScale = originalScaleOfParts * 1.3f;
                }
            }
        }

        else
        {
            if (parts[partToAttackNextIndex].hasClicked)
            {
                Attack();
                readyToAttak = false;
                parts[partToAttackNextIndex].readyToAttack = false;
                parts[partToAttackNextIndex].hasClicked = false;
                parts[partToAttackNextIndex].transform.localScale = originalScaleOfParts;
            }
        }
    }


    public void Attack()
    {
        audioPlayer.Play();
        Talk();
        timerAtack = 0;
        enemy.health -= atack;
        if (enemy.health <= 0)
        {
            enemyDeath = true;
        }

        Sequence mySequence = DOTween.Sequence();
        Vector3 initPos = transform.position;
        Vector3 finalPos = initPos;
        finalPos.x += 3;
        mySequence.Append(transform.DOMove(finalPos, 0.1f).SetEase(Ease.Linear));
        mySequence.Append(transform.DOMove(initPos, 0.1f).SetEase(Ease.Linear));

        Sequence eneMySecuence = DOTween.Sequence();
        Vector3 enemyInit = enemy.transform.position;
        Vector3 enemyFinalPos = enemyInit + Vector3.right;
        eneMySecuence.Append(enemy.transform.DOMove(enemyInit, 0.1f).SetEase(Ease.Linear));
        eneMySecuence.Append(enemy.transform.DOMove(enemyFinalPos, 0.1f).SetEase(Ease.Linear));
        eneMySecuence.Append(enemy.transform.DOMove(enemyInit, 0.1f).SetEase(Ease.Linear));
    }


    public void Talk()
    {
        float randValue = Random.value;
        if (randValue < .5f)
        {
            GameObject newDialogue = Instantiate(DialogueLine, placeOfDialogues);
            string currentLine = attackDialogues[indexDialogueAttack];
            newDialogue.GetComponent<ChangeDialogue>().ChangeText(currentLine);

            indexDialogueAttack++;
            if( indexDialogueAttack >= attackDialogues.Count )
            {
                indexDialogueAttack = 0;
            }
        }
    }
}
