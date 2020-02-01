using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pirate : MonoBehaviour
{
    [SerializeField]
    private ScriptableLimb defaultHead;
    private ScriptableLimb defaultLeftArm;
    private ScriptableLimb defaultRightArm;
    private ScriptableLimb defaultLeftLeg;
    private ScriptableLimb defaultRightLeg;

    private List<Limb> limbs;

    private bool dead;

    void Start()
    {
        limbs = new List<Limb>();

        for(int i = 0; i < 5;i++)
            limbs.Add(new Limb());

        limbs[LimbsIndexes.HEAD].Initialize(defaultHead);
        limbs[LimbsIndexes.LEFTARM].Initialize(defaultHead);
        limbs[LimbsIndexes.RIGHTARM].Initialize(defaultHead);
        limbs[LimbsIndexes.LEFTLEG].Initialize(defaultHead);
        limbs[LimbsIndexes.RIGHTARM].Initialize(defaultHead);

        dead = false;
    }

    void Update()
    {
        
    }

    public void TakeDamage(float amount)
    {
        // hit a random limb
        int index = Random.Range(0, 4);
        limbs[index].currentHP -= amount;

        // check if the pirate died
        if (GetCurrentHP() <= 0)
            dead = true;
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
        return dead;
    }
}
