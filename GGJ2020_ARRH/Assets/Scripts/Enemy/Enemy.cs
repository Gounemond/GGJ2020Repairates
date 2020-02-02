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

    public float multiplier;

    private float ticks;

    private int stage;

    public void Initialize(int stage)
    {
        this.stage = stage;
        float enemyMulti;
        if (stage % 4 == 0)
            enemyMulti = 0.9f;
        else
            enemyMulti = 0.7f;

        hp = hpBase * stage * enemyMulti;
        attack = attackBase * stage * 0.7f;

        // TODO balance
        multiplier = stage;

        attackPerSecond = attackPerSecondBase;

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
        if (!IsDead())
        {
            Debug.Log("enemy taking damage: " + hp + " " + amount);
            hp -= amount;

            if (hp <= 0)
            {
                int dropNumber;

                if (stage % 4 == 0)
                    dropNumber = Random.Range(4, 5);
                else
                    dropNumber = Random.Range(2, 4);
                Debug.Log("droppati " + dropNumber + " oggetti");
                for (int i = 0; i < dropNumber; i++)
                {
                    GameObject drop = Instantiate(dropsBase[Random.Range(0, dropsBase.Count - 1)], BackpackManager.Instance.transform);
                    Drop d;

                    d = drop.GetComponent<Drop>();

                    d.multiplier = multiplier;
                }


                Debug.Log("An enemy died!");
            }
        }
    }

    public bool IsDead()
    {
        return (hp <= 0);
    }
}
