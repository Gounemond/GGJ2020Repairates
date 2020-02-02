using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairMenuManager : MonoBehaviour
{
    public RectTransform rectButton;
    public RectTransform inventoryPanel;

    [Space]
    public float time;

    void Start()
    {
        Initializer();
    }

    

    private void Initializer()
    {
        rectButton.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width * 0.07f);
        rectButton.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height);

        //rectButton.rect.height = Screen.height;
    }



    // Update is called once per frame
    void Update()
    {

        ////scales up
        //if (isActive && !isActivated)
        //{
        //    StopAllCoroutines();
        //    StartCoroutine(AnimationPosition(1.5f, index));
        //    isActivated = true;
        //}

        ////scales down
        //else if (!isActive && isActivated)
        //{
        //    StopAllCoroutines();
        //    StartCoroutine(AnimationPosition(0, index));
        //    isActivated = false;
        //}

        
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
            inventoryPanel.localScale = new Vector3(newScale, 1.5f, 1);

            yield return eof;
        }
    }
}
