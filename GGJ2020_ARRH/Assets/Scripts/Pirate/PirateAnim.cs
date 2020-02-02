using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateAnim : MonoBehaviour
{

    public Animator pirateAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Attack()
    {
        pirateAnimator.SetTrigger("Attack");
    }

    public void GetHit()
    {
        pirateAnimator.SetTrigger("Hit");
    }

    public void Die()
    {
        pirateAnimator.SetTrigger("Death");
    }

    public void BeginDrag()
    {
        pirateAnimator.SetBool("Dragged",true);
    }

    public void EndDrag()
    {
        pirateAnimator.SetBool("Dragged", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
