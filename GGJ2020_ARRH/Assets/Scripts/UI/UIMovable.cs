using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIMovable : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    //when an item has been added or removed to the backpack
    public delegate void InsertedInBackpack();
    public InsertedInBackpack thisInsertion;

    public Transform outernCanvasTransform; //so when we parent to this while dragging the item stays above all the UI

    public RectTransform backpackContentTransform; // the parent to assign if the item has to snap to the backpack
    public RectTransform inventoryContentTransform; // the parent to assign if the item has to snap to the inventory

    public RectTransform backpackTransform; //the transform to check if the item is inside the backpack
    public RectTransform inventoryTransform; //the transform to check if the item is inside the inventory

    public Transform startingTransformParent;

    [Space]
    [TagSelector]
    public string InventoryTag = "";
    [TagSelector]
    public string BackpackTag = "";

    protected void Start()
    {
        startingTransformParent = transform.parent;
    }

    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(outernCanvasTransform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    // detects if the item is in the bag or inventory , if its neither , snap it to the older parent
    public virtual void OnEndDrag(PointerEventData eventData)
    {
        //sono nel backpack
        if (UIRaycast.Instance.currentTag == BackpackTag)
        {
            transform.SetParent(backpackContentTransform);
            startingTransformParent = backpackContentTransform;
        }
        //sono sull inventario
        else if (UIRaycast.Instance.currentTag == InventoryTag)
        {
            transform.SetParent(inventoryContentTransform);
            startingTransformParent = inventoryContentTransform;
        }
        else
        {
            transform.SetParent(startingTransformParent);
        }
    }
}
