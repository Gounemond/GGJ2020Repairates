using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsFactory
{
    [SerializeField]
    private ScriptableLimb defaultLimb;

    Limb GenerateLimb(int stage)
    {
        Limb limb = new Limb();
        limb.Initialize(defaultLimb);

        return limb;
    }
}
