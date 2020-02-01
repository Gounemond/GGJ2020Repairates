using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeManager : MonoBehaviour
{
    public PanelFader panelFader;

    // Start is called before the first frame update
    void Start()
    {
        panelFader.OnFadeInComplete += LoadNextScene;
        panelFader.OnFadeInComplete += Esplodi;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNextScene()
    {
        // Sarcazzi
    }

    public void Esplodi()
    {

    }
}
