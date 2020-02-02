using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limb
{
    public Material elementMat;
    public float maxHP;
    public float currentHP;
    public float attack;
    public float attackPerSecond;
    public bool melee;

    public void Initialize(ScriptableLimb data)
    {
        elementMat = data.elementMat;
        maxHP = data.maxHP;
        currentHP = data.maxHP;
        attack = data.attack;
        attackPerSecond = data.attackPerSecond;
        melee = data.melee;
    }
}
