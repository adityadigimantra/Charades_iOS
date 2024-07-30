using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridLayoutFix : MonoBehaviour
{
    public GridLayoutGroup gridLayout;
    public RectTransform contentRectTransform;
    public int numRows = 3;
    public int numColumns = 2;
    public float aspectRatio = 9 / 18f; // Change this to your desired aspect ratio

    void Start()
    {
        UpdateGridLayout();
    }

    void UpdateGridLayout()
    {
        float targetWidth = contentRectTransform.sizeDelta.x * aspectRatio;
        float targetHeight = contentRectTransform.sizeDelta.y / aspectRatio;

        float newCellSize = Mathf.Min(targetWidth / numColumns, targetHeight / numRows);

        gridLayout.cellSize = new Vector2(newCellSize, newCellSize);
    }
}

