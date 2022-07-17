using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GMTK2020;
public class Upgrade : MonoBehaviour
{
    public int GridPositionX, GridPositionY;

    public Grid mainGrid;

    public DiceSideType upgradeType;
    public void SetToGrid()
    {
        transform.position = mainGrid.CellToWorld(new Vector3Int(GridPositionX, 0, GridPositionY));
    }

    // Start is called before the first frame update
    void Start()
    {
        mainGrid = DataController.Instance.mainGrid;
        BoardController.Instance.Upgrades.Add(this);
        SetToGrid();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnDestroy()
    {
        BoardController.Instance.Upgrades.Remove(this);
    }
}

