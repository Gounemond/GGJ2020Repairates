using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableTile : MonoBehaviour
{

    private bool isOver = false;
    
    

    private void OnMouseDown()
    {
        Debug.Log("Ho clickato");

        if(transform.childCount > 0)
        {
           
            GetComponentInChildren<Transform>().position = Input.mousePosition;//new Vector3(Input.mousePosition.x/Screen.width, Input.mousePosition.y/Screen.height, transform.position.z);
        }
    }

    private void OnMouseUp()
    {
        if(isOver) Debug.Log("Ho draggato qua");

        if (transform.childCount == 0)
        {
            GetComponentInChildren<Transform>().position = transform.position;
        }
    }

    private void OnMouseOver()
    {
        GetComponent<SpriteRenderer>().color = Color.green;
        isOver = true;
    }

    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        isOver = false;
    }
}
