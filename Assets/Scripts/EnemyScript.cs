using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public Sprite injuredBodyPart;
    public int health;
    public int atack;
    public float timeToAtack;
    public PlayerScript player;
    public GameObject bodypartCard;
    public Image healthBar, attackBar;
    public SpriteRenderer bodyPartToAttack;
    

    private float timerAtack;
    private int maxHealth;
    private AudioSource audioEnemy;



    public void Awake()
    {
        audioEnemy = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    public void Start()
    {
        maxHealth = health;
        timerAtack = 0;
    }

    // Update is called once per frame
    public void Update()
    {
        healthBar.fillAmount = (float)health/(float)maxHealth;
        attackBar.fillAmount = timerAtack/timeToAtack;

        timerAtack += Time.deltaTime;
        if (timerAtack > timeToAtack)
        {
            audioEnemy.Play();
            AnimateAtack();
            timerAtack = 0;
            player.health -= atack;
        }

        if (health <= 0)
        {
            bodypartCard.SetActive(true);
            bodyPartToAttack.sprite = injuredBodyPart;
            gameObject.SetActive(false);
        }
    }

    public void AnimateAtack()
    {
        Sequence mySequence = DOTween.Sequence();
        Vector3 initPos = transform.position;
        Vector3 finalPos = initPos + Vector3.left;
        mySequence.Append(transform.DOMove(finalPos, 0.1f).SetEase(Ease.Linear));
        mySequence.Append(transform.DOMove(initPos, 0.1f).SetEase(Ease.Linear));
    }
}
