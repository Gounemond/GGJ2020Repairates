using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RepairMenuManager : MonoBehaviour
{
    public RectTransform rectButton;
    public RectTransform inventoryPanel;

    [Space]
    public float time;

    private bool isActive = false;

    void Start()
    {
        Initializer();
    }

    

    private void Initializer()
    {
        rectButton.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width * 0.04f);
        rectButton.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height);


        //inventoryPanel.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width * 0.33f);
        //inventoryPanel.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height);
    }


    void Update()
    {
        ////scales up
        //if (isActive)
        //{
        //    StopAllCoroutines();
        //    StartCoroutine(AnimationPosition(1f));
        //    //isActivated = true;
        //}

        ////scales down
        //else if (!isActive)
        //{
        //    StopAllCoroutines();
        //    StartCoroutine(AnimationPosition(0));
        //    //isActivated = false;
        //}
    }

    
    public void OpenClosePanel()
    {
        if (isActive)
        {
            isActive = false;
            inventoryPanel.transform.DOMoveX(100, 0);
        }
        else
        {
            isActive = true;
            inventoryPanel.transform.DOMoveX(-100, 0);
        }
    }


    //scale by a value
    protected IEnumerator AnimationPosition(float finalScale)
    {
        WaitForEndOfFrame eof = new WaitForEndOfFrame();
        float startValue = inventoryPanel.localScale.x;
        float animationAmount = 0.0f;
        float speed = 1.0f / time;

        while (animationAmount < 1.0f)
        {
            animationAmount = Mathf.Min(1.0f, animationAmount + Time.deltaTime * speed);

            float newScale = Mathf.Lerp(startValue, finalScale, animationAmount);
            inventoryPanel.localScale = new Vector3(newScale, 1, 1);

            yield return eof;
        }
    }
}
