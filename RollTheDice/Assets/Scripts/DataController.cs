using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GMTK2020;

public class DataController : MonoBehaviour
{
    public static DataController Instance;
    public Grid mainGrid;
    public GameObject hwall;
    public GameObject vwall;
    public GameObject corner;

    public int[,] mapGrid; // 1-hwall, 2-vwall, 3 corner
    private void Awake()
    {




                if (Instance == null)
            Instance = this;

        foreach(SideScriptable a  in allSides)
        {
            allSidesDict.Add(a.type, a);
        }

        mapGrid = new int[,]
        {
                 {3,1,1,1,1,1,1,3},
                 {2,0,0,0,0,0,0,2},
                 {2,0,0,0,0,0,0,2},
                 {2,0,0,0,0,0,0,2},
                 {2,0,0,0,0,0,0,2},
                 {2,0,0,0,0,0,0,2},
                 {2,0,0,0,0,0,0,2},
                 {3,1,1,1,1,1,1,3}

        };

        for (int i = 0; i < mapGrid.GetLength(0); i++)
            for (int j = 0; j < mapGrid.GetLength(0); j++)
            {
                GameObject gj = null;
                switch (mapGrid[i, j])
                {
                    case 1:
                        gj = Instantiate(hwall);
                        break;
                    case 2:
                        gj = Instantiate(vwall);
                        break;
                    case 3:
                        gj = Instantiate(corner);
                        break;

                }
                if (gj != null)
                {
                    Wall w = gj.GetComponent<Wall>();
                    w.mainGrid = mainGrid;
                    w.GridPositionX = j;
                    w.GridPositionY = i;
                    w.SetToGrid();
                }

            }
    }
    public List<SideScriptable> allSides = new List<SideScriptable>();
    public Dictionary<DiceSideType, SideScriptable> allSidesDict = new Dictionary<DiceSideType, SideScriptable>(); 
}
