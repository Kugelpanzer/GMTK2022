using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GMTK2020;
public class Wall : MonoBehaviour
{
    public int GridPositionX, GridPositionY;

    public Grid mainGrid;
    public void SetToGrid()
    {
        transform.position = mainGrid.CellToWorld(new Vector3Int(GridPositionX, 0, GridPositionY));
    }

    // Start is called before the first frame update
    void Start()
    {
        BoardController.Instance.Walls.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
