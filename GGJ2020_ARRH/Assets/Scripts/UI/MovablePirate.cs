using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovablePirate : MonoBehaviour
{
    public LayerMask draggableLayer;
    public Transform draggingLayer;
    public OpenCloseInventory inventoryOpener;

    [HideInInspector]
    public Transform startingPos;
    [HideInInspector]
    public Transform goingPos;
    [HideInInspector]
    public Transform oldPos;

    [HideInInspector]
    public Transform otherPirate;
    [HideInInspector]
    public bool isOccupied = false;
    [HideInInspector]
    public bool hasHit = false;

    private Vector3 mOffset;
    private float mZCoord;

    private bool hasDrag = false;

    [SerializeField]
    private LastRow LastRow;

    private void Start()
    {
        inventoryOpener = FindObjectOfType<OpenCloseInventory>();
        Debug.Log("Yeah");
    }

    void OnMouseDown()
    {
        if (transform.GetComponentInParent<LastRow>()) LastRow = transform.GetComponentInParent<LastRow>();

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

                    goingPos = hit.transform;

                    hasHit = true;
                }
                else
                {
                    isOccupied = false;
                    goingPos = hit.transform;
                    hasHit = true;
                }
            }
        }
        else
        {
            hasDrag = true;

            isOccupied = false;
            hasHit = false;

            oldPos = null;
            otherPirate = null;

            goingPos = startingPos;

            Debug.DrawRay(transform.position, Vector3.forward * 100, Color.white);
            Debug.Log("Did not Hit");

        }
    }

    private void OnMouseUp()
    {
     
        if(!hasDrag && LastRow)
        {
            UIPirate.Instance.pirate = GetComponent<Pirate>();

            UIPirate.Instance.image.texture = LastRow.renderTexture;

            // Apri menu
            Debug.Log("Hello maddabboyz");
            inventoryOpener.OpenInventory();

            UIPirate.Instance.PopulateInventory();
        }

        hasDrag = false;

        if(!isOccupied)
        {
            transform.SetParent(goingPos);
            transform.position = new Vector3(goingPos.position.x, goingPos.position.y, goingPos.position.z - 0.1f);
            isOccupied = false;
            hasHit = false;

            startingPos = null;
            goingPos = null;
            oldPos = null;
            otherPirate = null;
        }
        else
        {
            otherPirate.transform.SetParent(oldPos);
            otherPirate.transform.position = new Vector3(oldPos.position.x, oldPos.position.y, goingPos.position.z - 0.1f);

            transform.SetParent(goingPos);
            transform.position = new Vector3(goingPos.position.x, goingPos.position.y, goingPos.position.z - 0.1f);
            isOccupied = false;
            hasHit = false;

            MovablePirate pirate = otherPirate.transform.GetComponent<MovablePirate>();

            pirate.startingPos = null;
            pirate.goingPos = null;
            pirate.oldPos = null;
            pirate.otherPirate = null;

            startingPos = null;
            goingPos = null;
            oldPos = null;
            otherPirate = null;
        }
   
    }

}