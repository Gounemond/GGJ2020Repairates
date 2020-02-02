using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseInventory : MonoBehaviour
{
    public Animator inventoryAnimator;

    private bool isClosed = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OpenInventory()
    {
        inventoryAnimator.SetBool("IsOpen", true);
        isClosed = false;
    }

    public void CloseInventory()
    {
        if (isClosed)
        {
            inventoryAnimator.SetBool("IsOpen", true);
            isClosed = false;
        }
        else
        {
            inventoryAnimator.SetBool("IsOpen", false);
            isClosed = true;
        }

    }
}
