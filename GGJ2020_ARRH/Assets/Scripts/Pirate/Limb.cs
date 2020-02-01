﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limb
{
    public Sprite sprite;
    public float maxHP;
    public float currentHP;
    public float attack;
    public bool melee;

    public void Initialize(ScriptableLimb data)
    {
        sprite = data.sprite;
        maxHP = data.maxHP;
        currentHP = data.maxHP;
        attack = data.attack;
        melee = data.melee;
    }
}