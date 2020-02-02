using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackManager : MonoBehaviour
{
    public static BackpackManager Instance;

    void Start()
    {
        Instance = this;
    }
}
