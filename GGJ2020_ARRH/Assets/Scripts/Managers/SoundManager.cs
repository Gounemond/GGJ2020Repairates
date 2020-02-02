using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeManager : MonoBehaviour
{
    public PanelFader panelFader;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(panelFader.FadeOut());
        panelFader.OnFadeInComplete += LoadNextScene;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeToNextScene()
    {
        StartCoroutine(panelFader.FadeIn());
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(1);
    }
}
