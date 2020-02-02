using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpdateScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int stage = ScoreSingleton.Instance.stage;
        GetComponent<Text>().text = "You arrrh-ivved at stage " + stage + ", matey!";
        StartCoroutine(Sleep());
    }

    IEnumerator Sleep()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("0_HomeScreen");
    }
}
