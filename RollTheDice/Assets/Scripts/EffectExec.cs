using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectExec : MonoBehaviour
{

    public float durationTimer = 2f;
    public int GridPositionX;
    public int GridPositionY;
    Grid mainGrid;
    public float offsetX = 0;
    public float offsetY = 0;
    // Start is called before the first frame update
    void Start()
    {
        mainGrid = DataController.Instance.mainGrid;
    }
    public void SetToGrid()
    {
        transform.position = mainGrid.CellToWorld(new Vector3Int(GridPositionX, 0, GridPositionY)) + new Vector3(offsetX,0,offsetY);

    }

    // Update is called once per frame
    void Update()
    {
        SetToGrid();
        if (durationTimer > 0)
        {
            durationTimer -= Time.fixedDeltaTime;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
