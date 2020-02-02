using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackpackSize : MonoBehaviour
{
    public RectTransform basePanel;

    private GridLayoutGroup grid;

    void Start()
    {
        grid = GetComponent<GridLayoutGroup>();

        grid.cellSize = new Vector2(basePanel.rect.height * 0.8f, basePanel.rect.height * 0.8f);

        basePanel.sizeDelta = new Vector2((grid.cellSize.x*(basePanel.transform.childCount-1)), basePanel.sizeDelta.y);

        basePanel.localPosition = new Vector2(0, 0);
    }
    
}
