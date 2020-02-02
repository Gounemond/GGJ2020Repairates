using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class ScoreSingleton
{
    public int stage;
    ScoreSingleton()
    {
    }
    private static readonly object padlock = new object();
    private static ScoreSingleton instance = null;
    public static ScoreSingleton Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new ScoreSingleton();
                }
                return instance;
            }
        }
    }
}
