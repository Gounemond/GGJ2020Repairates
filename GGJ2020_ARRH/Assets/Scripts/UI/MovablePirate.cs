using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovablePirate : MonoBehaviour
{
    public LayerMask draggableLayer;

    private Vector3 mOffset;
    private float mZCoord;

    public Transform draggingLayer;

    [SerializeField] private Transform startingPos;
    [SerializeField] private Transform oldPos;

    [SerializeField] private Transform otherPirate;
    [SerializeField] private bool isOccupied = false;
    [SerializeField] private bool hasHit = false;

    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();

        startingPos = transform.parent.transform;

        transform.SetParent(draggingLayer);
    }


    private Vector3 GetMouseAsWorldPoint()
    {
        Vector3 mousePoint = Input.mousePosition;
        
        mousePoint.z = mZCoord;
        
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    
    void OnMouseDrag()
    {
        transform.position = GetMouseAsWorldPoint() + mOffset;


        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, 100, draggableLayer))
        {
            Debug.DrawRay(transform.position, Vector3.forward * hit.distance, Color.yellow);
            Debug.Log("Did Hit");

            if(!hasHit)
            {
                if (hit.transform.childCount > 0)
                {
                    otherPirate = hit.transform.GetChild(0).GetComponent<Transform>();

                    isOccupied = true;

                    oldPos = startingPos;

                    startingPos = hit.transform;

                    hasHit = true;
                }
                else
                {
                    isOccupied = false;
                    startingPos = hit.transform;
                    hasHit = true;
                }
            }
            
            
        }
        else
        {
            isOccupied = false;
            hasHit = false;
            Debug.DrawRay(transform.position, Vector3.forward * 100, Color.white);
            Debug.Log("Did not Hit");
        }
    }

    private void OnMouseUp()
    {
        
        if(!isOccupied)
        {
            transform.SetParent(startingPos);
            transform.position = new Vector3(startingPos.position.x, startingPos.position.y, transform.position.z);
            isOccupied = false;
            hasHit = false;
        }
        else
        {
            otherPirate.transform.SetParent(oldPos);
            otherPirate.transform.position = oldPos.position;

            transform.SetParent(startingPos);
            transform.position = new Vector3(startingPos.position.x, startingPos.position.y, transform.position.z);
            isOccupied = false;
            hasHit = false;
        }
   
    }

}