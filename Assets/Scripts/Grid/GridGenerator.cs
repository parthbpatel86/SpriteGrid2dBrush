using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GridPopulator : MonoBehaviour
{
    [SerializeField] int rows = 5; // Number of rows in the grid
    [SerializeField] int columns = 5; // Number of columns in the grid
    [SerializeField] float gridWidth = 10f; // Total width of the grid
    [SerializeField] float gridHeight = 10f; // Total height of the grid
    [SerializeField] float spacing = 0.1f; // Spacing between each sprite
    [SerializeField] GridCell _cellPrefab;

    void Start()
    {
        // Calculate the available width and height for each cell (sprite) considering the spacing
        float cellWidth = (gridWidth - (spacing * (columns - 1))) / columns;
        float cellHeight = (gridHeight - (spacing * (rows - 1))) / rows;

        // Calculate the final sprite size to fit within each cell
        Vector2 spriteSize = new Vector2(cellWidth, cellHeight);

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                // Calculate the position for each sprite
                float xPos = (col * (cellWidth + spacing)) - (gridWidth / 2) + (cellWidth / 2);
                float yPos = (row * (cellHeight + spacing)) - (gridHeight / 2) + (cellHeight / 2);
                Vector2 position = new Vector2(xPos, yPos);

                // Instantiate the sprite prefab at the calculated position
                GameObject spriteInstance = Instantiate(_cellPrefab.gameObject, position, Quaternion.identity, transform);

                // Adjust the sprite size to fit the cell
                spriteInstance.transform.localScale = new Vector3(spriteSize.x / spriteInstance.GetComponent<SpriteRenderer>().bounds.size.x,
                                                                 spriteSize.y / spriteInstance.GetComponent<SpriteRenderer>().bounds.size.y,
                                                                 1f);

                // Optionally, rename each sprite instance for organization
                spriteInstance.name = $"Sprite_{row}_{col}";
            }
        }
    }
}
