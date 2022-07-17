using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public int GridPositionX, GridPositionY;

    public Grid mainGrid;
    public void SetToGrid()
    {
        transform.position = mainGrid.CellToWorld(new Vector3Int(GridPositionX, 0, GridPositionY));
    }
}
