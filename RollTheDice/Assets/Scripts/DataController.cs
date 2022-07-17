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

    public GameObject floor;

    public GameObject upHalfWall;
    public GameObject downHalfWall;
    public GameObject rightHalfWall;
    public GameObject leftHalfWall;

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
                 {3,1,1,1,1,1,1,1,3},
                 {2,0,0,0,0,0,0,0,2},
                 {2,0,0,0,0,0,0,0,2},
                 {2,0,0,0,0,0,0,0,2},
                 {2,0,0,0,0,0,0,0,2},
                 {2,0,0,0,0,0,0,0,2},
                 {2,0,0,0,0,0,0,0,2},
                 {2,0,0,0,0,0,0,0,2},
                 {3,1,1,1,1,1,1,1,3}

        };

        for (int i = 0; i < mapGrid.GetLength(0); i++)
            for (int j = 0; j < mapGrid.GetLength(0); j++)
            {
                GameObject fgj = null;
                GameObject gj = null;
                bool cFlag = false;
               
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
                        cFlag = true;
                        break;

                }
                if (gj != null)
                {
                    Wall w = gj.GetComponent<Wall>();
                    w.mainGrid = mainGrid;
                    w.GridPositionX = j;
                    w.GridPositionY = i;
                    w.SetToGrid();
                    gj.transform.position += new Vector3(0, -1, 0);
                }
                fgj = Instantiate(floor);
                Floor f = fgj.GetComponent<Floor>();
                f.mainGrid = mainGrid;
                f.GridPositionX = j;
                f.GridPositionY = i;
                f.SetToGrid();
                fgj.transform.position += new Vector3(0, -1, 0);

                if (cFlag)
                {
                    
                    /*if(BoardController.Instance.isOccupiedTileType(j+1,i)==CritterType.wall )
                    {
                        GameObject ggj = Instantiate(rightHalfWall);
                        ggj.transform.position = gj.transform.position;
                    }
                    if (BoardController.Instance.isOccupiedTileType(j - 1, i) == CritterType.wall)
                    {
                        GameObject ggj = Instantiate(leftHalfWall);
                        ggj.transform.position = gj.transform.position;
                    }
                    if (BoardController.Instance.isOccupiedTileType(j , i-1) == CritterType.wall)
                    {
                        GameObject ggj = Instantiate(upHalfWall);
                        ggj.transform.position = gj.transform.position;
                    }
                    if (BoardController.Instance.isOccupiedTileType(j, i+1) == CritterType.wall)
                    {
                        GameObject ggj = Instantiate(downHalfWall);
                        ggj.transform.position = gj.transform.position;
                    }*/
                }

            }
    }
    public List<SideScriptable> allSides = new List<SideScriptable>();
    public Dictionary<DiceSideType, SideScriptable> allSidesDict = new Dictionary<DiceSideType, SideScriptable>(); 
}
