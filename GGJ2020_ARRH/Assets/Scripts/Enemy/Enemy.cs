using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hpBase;
    public float attackBase;
    public float attackPerSecondBase;
    public List<GameObject> dropsBase;

    public float hp;
    public float attack;
    public float attackPerSecond;
    public List<GameObject> drops;

    private float ticks;

    public void Initialize(int stage)
    {
        hp = hpBase * stage;
        attack = attackBase * stage;
        attackPerSecond = attackPerSecondBase;
        drops = dropsBase;

        Debug.Log("Generated an enemy: \nhp: "+hp+"\nattack: "+attack);
    }

    private void Start()
    {
        ticks = 0;
    }

    private void Update()
    {
        ticks += Time.deltaTime;

        if (ticks >= attackPerSecond)
        {
            ticks = 0;
            Attack();
        }
    }

    private void Attack()
    {
        Debug.Log("An enemy is attacking!");
        GameManager.Instance.AttackCrew(attack);
    }

    public void TakeDamage(float amount)
    {
        Debug.Log("enemy taking damage: " + hp +" "+amount);
        hp -= amount;

        if (hp <= 0)
            Debug.Log("An enemy died!");
    }

    public bool IsDead()
    {
        return (hp <= 0);
    }
}
