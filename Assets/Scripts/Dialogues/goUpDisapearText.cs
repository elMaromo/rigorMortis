using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class goUpDisapearText : MonoBehaviour
{
    public float timeStatic, timeUp, distanceUp;
    public TextMeshProUGUI textOfLine;
    public Image uiImage;

    private float timerAlive;

    // Start is called before the first frame update
    void Start()
    {
        timerAlive = 0;
        
        Vector3 posEnd = transform.position;
        posEnd.y += distanceUp;

        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOMove(transform.position, timeStatic));
        mySequence.Append(transform.DOMove(posEnd, timeUp).SetEase(Ease.Linear));
    }

    // Update is called once per frame
    void Update()
    {
        timerAlive += Time.deltaTime;

        if(timerAlive >= ( timeStatic + timeUp ) )
        {
            Destroy(this.gameObject);
        }

        if( timerAlive > timeStatic )
        {
            ChangeColorTextAndImage();
        }
        
    }


    public void ChangeColorTextAndImage()
    {
        float nextAlpha = 1 - (timerAlive - timeStatic)/timeUp;

        Color tempColor = uiImage.color;
        tempColor.a = nextAlpha;
        uiImage.color = tempColor;

        textOfLine.alpha = nextAlpha;
    }
}
