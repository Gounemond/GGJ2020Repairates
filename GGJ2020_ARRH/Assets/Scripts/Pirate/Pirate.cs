using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pirate : MonoBehaviour
{
    [SerializeField]
    private ScriptableLimb defaultHead;
    [SerializeField]
    private ScriptableLimb defaultLeftArm;
    [SerializeField]
    private ScriptableLimb defaultRightArm;
    [SerializeField]
    private ScriptableLimb defaultLeftLeg;
    [SerializeField]
    private ScriptableLimb defaultRightLeg;

    private List<Limb> limbs;

    // if the pirate is not on the bridge he cannot attack
    private bool canAttack;

    void Start()
    {
        Debug.Log("a new pirate is started!");
        limbs = new List<Limb>();

        for (int i = 0; i < 5;i++)
            limbs.Add(new Limb());

        if (limbs[LimbsIndexes.HEAD] == null)
            Debug.Log("ouch");
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
        int index = Random.Range(0, 4);
        limbs[index].currentHP -= amount;

        // check if the pirate died
        if (GetCurrentHP() <= 0)
        {
            CantAttack();
            Debug.Log("A pirate died!");
        }
    }
    private void Attack()
    {
        if (canAttack)
        {
            Debug.Log("A pirate is attacking with " + GetTotalAttack());
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
        return GetCurrentHP() <= 0;
    }

    public List<Limb> GetLimbs()
    {
        return limbs;
    }
}
