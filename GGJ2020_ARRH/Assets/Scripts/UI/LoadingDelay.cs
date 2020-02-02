using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingDelay : MonoBehaviour
{
    public float timer;

    public int sceneIndex;

    void Start()
    {
        Invoke("LoadScene", timer);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
