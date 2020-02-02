using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class PanelFader : MonoBehaviour
{

    public event Action OnFadeInComplete;                   // This event is triggered when the UI elements have finished fading in.
    public event Action OnFadeOutComplete;                  // This event is triggered when the UI elements have finished fading out.

    [SerializeField] private float m_FadeSpeed = 1f;        // The amount the alpha of the UI elements changes per second.
    [SerializeField] private Image m_FadePanel;             // All the groups of UI elements that will fade in and out.

    private Color tempColor;


    private bool m_Fading;                                  // Whether the UI elements are currently fading in or out.


    public bool Visible { get; private set; }               // Whether the UI elements are currently visible.

    public void Start()
    {

    }


    public IEnumerator WaitForFadeIn()
    {
        // Keep coming back each frame whilst the groups are currently fading.
        while (m_Fading)
        {
            yield return null;
        }

        // Return once the FadeIn coroutine has finished.
        yield return StartCoroutine(FadeIn());
    }


    public IEnumerator InteruptAndFadeIn()
    {
        // Stop all fading that is currently happening.
        StopAllCoroutines();

        // Return once the FadeIn coroutine has finished.
        yield return StartCoroutine(FadeIn());
    }


    public IEnumerator CheckAndFadeIn()
    {
        // If not already fading return once the FadeIn coroutine has finished.
        if (!m_Fading)
            yield return StartCoroutine(FadeIn());
    }


    public IEnumerator FadeIn()
    {
        // Fading has now started.
        m_Fading = true;

        // Fading needs to continue until all the groups have finishing fading in so we need to base that on the lowest alpha.
        float lowestAlpha;

        do
        {
            // Assume the lowest alpha has faded in already.
            lowestAlpha = 1f;

            // ... and increment their alpha based on the fade speed.
            tempColor = new Color(m_FadePanel.color.r, m_FadePanel.color.g, m_FadePanel.color.b, m_FadePanel.color.a + m_FadeSpeed * Time.deltaTime);
            m_FadePanel.color = tempColor;

            // Also we need to check what the lowest alpha is.
            if (m_FadePanel.color.a < lowestAlpha)
            {
                lowestAlpha = m_FadePanel.color.a;
            }

            // Wait until next frame.
            yield return null;
        }
        // Continue doing this until the lowest alpha is one or greater.
        while (lowestAlpha < 1f);

        // If there is anything subscribed to OnFadeInComplete, call it.
        if (OnFadeInComplete != null)
            OnFadeInComplete();

        // Fading has now finished.
        m_Fading = false;

        // Since everthing has faded in now, it is visible.
        Visible = true;
    }


    // The following functions are identical to the previous ones but fade the CanvasGroups out instead.
    public IEnumerator WaitForFadeOut()
    {
        while (m_Fading)
        {
            yield return null;
        }

        yield return StartCoroutine(FadeOut());
    }


    public IEnumerator InteruptAndFadeOut()
    {
        StopAllCoroutines();
        yield return StartCoroutine(FadeOut());
    }


    public IEnumerator CheckAndFadeOut()
    {
        if (!m_Fading)
            yield return StartCoroutine(FadeOut());
    }


    public IEnumerator FadeOut()
    {
        m_Fading = true;

        float highestAlpha;

        do
        {
            highestAlpha = 0f;


            tempColor = new Color(m_FadePanel.color.r, m_FadePanel.color.g, m_FadePanel.color.b, m_FadePanel.color.a - m_FadeSpeed * Time.deltaTime);
            m_FadePanel.color = tempColor;

            if (m_FadePanel.color.a > highestAlpha)
            {
                highestAlpha = m_FadePanel.color.a;
            }

            yield return null;
        }
        while (highestAlpha > 0f);

        if (OnFadeOutComplete != null)
            OnFadeOutComplete();

        m_Fading = false;

        Visible = false;
    }


    // These functions are used if fades are required to be instant.
    public void SetVisible()
    {
        tempColor = new Color(m_FadePanel.color.r, m_FadePanel.color.g, m_FadePanel.color.b, 1);
        m_FadePanel.color = tempColor;

        Visible = true;
    }


    public void SetInvisible()
    {
        tempColor = new Color(m_FadePanel.color.r, m_FadePanel.color.g, m_FadePanel.color.b, 0);
        m_FadePanel.color = tempColor;

        Visible = false;
    }
}
