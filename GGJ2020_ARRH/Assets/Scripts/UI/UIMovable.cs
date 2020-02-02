﻿using System.Collections;
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
    public RectTransform rightArmContentTransform; // the parent to assign if the item has to snap to the right arm
    public RectTransform leftArmContentTransform; // the parent to assign if the item has to snap to the right arm
    public RectTransform rightLegContentTransform; // the parent to assign if the item has to snap to the right arm
    public RectTransform leftLegContentTransform; // the parent to assign if the item has to snap to the right arm

    public Transform startingTransformParent;

    [Space]
    [TagSelector]
    public string rightArmTag = "";
    [TagSelector]
    public string leftArmTag = "";
    [TagSelector]
    public string rightLegTag = "";
    [TagSelector]
    public string leftLegTag = "";
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
        else if (UIRaycast.Instance.currentTag == rightArmTag)
        {
            if(rightArmContentTransform.transform.childCount > 0)
            {
                Destroy(rightArmContentTransform.transform.GetChild(0).gameObject);
            }

            transform.SetParent(rightArmContentTransform);
            startingTransformParent = rightArmContentTransform;
            this.enabled = false;
        }
        else if (UIRaycast.Instance.currentTag == leftArmTag)
        {
            if (leftArmContentTransform.transform.childCount > 0)
            {
                Destroy(leftArmContentTransform.transform.GetChild(0).gameObject);
            }

            transform.SetParent(leftArmContentTransform);
            startingTransformParent = leftArmContentTransform;
            this.enabled = false;
        }
        else if (UIRaycast.Instance.currentTag == rightLegTag)
        {
            if (rightLegContentTransform.transform.childCount > 0)
            {
                Destroy(rightLegContentTransform.transform.GetChild(0).gameObject);
            }

            transform.SetParent(rightLegContentTransform);
            startingTransformParent = rightLegContentTransform;
            this.enabled = false;
        }
        else if (UIRaycast.Instance.currentTag == leftLegTag)
        {
            if (leftLegContentTransform.transform.childCount > 0)
            {
                Destroy(leftLegContentTransform.transform.GetChild(0).gameObject);
            }

            transform.SetParent(leftLegContentTransform);
            startingTransformParent = leftLegContentTransform;
            this.enabled = false;
        }
        else
        {
            transform.SetParent(startingTransformParent);
        }
    }
}
