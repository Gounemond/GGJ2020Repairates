﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pirate : MonoBehaviour
{
    public Action Ondeath;

    [SerializeField] private PirateAnim pirateAnim;

    [SerializeField]
    public ScriptableLimb defaultHead;
    [SerializeField]
    public ScriptableLimb defaultLeftArm;
    [SerializeField]
    public ScriptableLimb defaultRightArm;
    [SerializeField]
    public ScriptableLimb defaultLeftLeg;
    [SerializeField]
    public ScriptableLimb defaultRightLeg;

    private List<Limb> limbs;

    // if the pirate is not on the bridge he cannot attack
    private bool canAttack;

    void Start()
    {
        Debug.Log("a new pirate is started!");
        limbs = new List<Limb>();

        for (int i = 0; i < 5;i++)
            limbs.Add(new Limb());

        limbs[LimbsIndexes.HEAD].Initialize(defaultHead);
        limbs[LimbsIndexes.LEFTARM].Initialize(defaultLeftArm);
        limbs[LimbsIndexes.RIGHTARM].Initialize(defaultRightArm);
        limbs[LimbsIndexes.LEFTLEG].Initialize(defaultLeftLeg);
        limbs[LimbsIndexes.RIGHTLEG].Initialize(defaultRightArm);
        Debug.Log("a new pirate is born!");

        canAttack = false;

        ticks = Time.time;
    }

    public float attackPerSecond = 1;
    private float ticks;
    private void Update()
    {
        if (Time.time - ticks >= attackPerSecond)
        {
            ticks = Time.time;
            Attack();
        }
    }

    public void CanAttack()
    {
        canAttack = true;
    }
    public void CantAttack()
    {
        canAttack = false;
    }

    public void TakeDamage(float amount)
    {
        // hit a random limb
        int index = UnityEngine.Random.Range(0, 4);
        limbs[index].currentHP -= amount;

        // Play anims and sounds
        pirateAnim.GetHit();

        // check if the pirate died
        if (GetCurrentHP() <= 0)
        {
            CantAttack();
            pirateAnim.Die();
            StartCoroutine(DieGracefully());
            Debug.Log("A pirate died!");
        }
    }
    private void Attack()
    {
        if (canAttack)
        {
            Debug.Log("A pirate is attacking with " + GetTotalAttack());
            pirateAnim.Attack();
            GameManager.Instance.AttackEnemy(GetTotalAttack());
        }
    }

    public float GetTotalAttack()
    {
        float total = 0;
        foreach (Limb limb in limbs)
            total += limb.attack;
        return total;
    }
    public float GetTotalHP()
    {
        float total = 0;
        foreach (Limb limb in limbs)
            total += limb.maxHP;
        return total;
    }
    public float GetCurrentHP()
    {
        float total = 0;
        foreach (Limb limb in limbs)
            total += limb.currentHP;
        return total;
    }

    public bool IsDead()
    {
        return (GetCurrentHP() <= 0);
    }

    public List<Limb> GetLimbs()
    {
        return limbs;
    }

    private IEnumerator DieGracefully()
    {
        yield return new WaitForSeconds(3);
        this.gameObject.SetActive(false);
    }
}
