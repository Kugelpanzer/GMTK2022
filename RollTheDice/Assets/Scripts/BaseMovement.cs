using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMovement : MonoBehaviour
{
    public Grid mainGrid;
    public int gridX = 5;
    public int gridY = 5;

    public float moveSpeed = 2;

    public bool moving = false;

    public float offset = 0.1f;
    
    public void SetToGrid()
    {
        transform.position = mainGrid.CellToWorld(new Vector3Int(gridX,0, gridY));
    }



    public void Start()
    {
        SetToGrid();
    }

    // Update is called once per frame
    public void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, mainGrid.CellToWorld(new Vector3Int(gridX, 0, gridY)), moveSpeed * Time.deltaTime);
    }
}
