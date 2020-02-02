using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPirate : MonoBehaviour
{
    public static UIPirate Instance;

    public Pirate pirate;

    public Drop drop;

    [Space]
    public GameObject rightArm;
    public GameObject leftArm;
    public GameObject rightLeg;
    public GameObject leftLeg;

    public RawImage image;

    void Start()
    {
        Instance = this;
        
    }


    public void PopulateInventory()
    {
        ClearPosition();

        Drop armR = Instantiate(drop, rightArm.transform);
        Drop armL = Instantiate(drop, leftArm.transform);
        Drop legR = Instantiate(drop, rightLeg.transform);
        Drop legL = Instantiate(drop, leftLeg.transform);

        armR.limb = pirate.defaultRightArm;
        armL.limb = pirate.defaultLeftArm;
        legL.limb = pirate.defaultLeftLeg;
        legR.limb = pirate.defaultRightLeg;
    }
    
    private void ClearPosition()
    {
        if(rightArm.transform.childCount > 0) Destroy(rightArm.transform.GetChild(0).gameObject);
        if(leftArm.transform.childCount > 0) Destroy(leftArm.transform.GetChild(0).gameObject);
        if(rightLeg.transform.childCount > 0) Destroy(rightLeg.transform.GetChild(0).gameObject);
        if(leftLeg.transform.childCount > 0) Destroy(leftLeg.transform.GetChild(0).gameObject);
    }

    //da chiamare quando muore il pirata
    public void ClearPirate()
    {
        pirate = null;

        ClearPosition();
    }
}
