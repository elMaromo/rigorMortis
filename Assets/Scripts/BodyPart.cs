using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BodyPart : MonoBehaviour
{
    public GameObject indicator;
    public LayerMask layerParts;
    public string nextLevelName;
    public Transform playerTransform;
    public string tagOfPart;

    private Vector3 offset;
    private Vector3 screenPoint;
    private Vector3 originalPos;
    private bool moved, grabbed;

    // Start is called before the first frame update
    void Start()
    {
        moved = false;
        originalPos = transform.position;
        grabbed = false;
    }

    void OnMouseDown()
    {
        if (!moved)
        {
            indicator.SetActive(false);
            grabbed = true;
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            Vector3 currOffsetWorldPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(currOffsetWorldPos);
        }
    }

    void OnMouseDrag()
    {
        if (grabbed)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
        }
    }

    void OnMouseUp()
    {
        if (grabbed)
        {
            grabbed = false;
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            RaycastHit2D hit = Physics2D.Raycast(curPosition, Vector2.zero, Mathf.Infinity, layerParts);

            if (hit.collider != null && hit.collider.CompareTag(tagOfPart))
            {
                moved = true;
                gameObject.transform.parent = playerTransform.transform;
                //WinAnimation( hit.collider.gameObject.transform.position );
                SceneManager.LoadScene(nextLevelName);
                
            }
            else
            {
                indicator.SetActive(true);
                transform.DOMove(originalPos, 0.2f);
            }
        }
    }


    public void WinAnimation( Vector3 partPosition )
    {
        Sequence mySequence = DOTween.Sequence();
        Vector3 initPos = playerTransform.position;
        Vector3 finalPos = initPos;
        finalPos.x += 20;
        mySequence.Append(transform.DOMove(partPosition, 0.2f));
        mySequence.Append(playerTransform.DOMove(finalPos, 1f).SetEase(Ease.Linear));
    }
}
