using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Limb", menuName = "ScriptableObjects/TheRepairates/Limb", order = 1)]
public class ScriptableLimb : ScriptableObject
{
    public Material elementMat;
    public float maxHP;
    public float attack;
    public float attackPerSecond;
    public bool melee; // false = weapon is ranged
}
