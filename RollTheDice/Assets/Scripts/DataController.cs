using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GMTK2020;

public class DataController : MonoBehaviour
{
    public static DataController Instance;
    private void Awake()
    {
        if(Instance == null)
            Instance = this;

        foreach(SideScriptable a  in allSides)
        {
            allSidesDict.Add(a.type, a);
        }
    }
    public List<SideScriptable> allSides = new List<SideScriptable>();
    public Dictionary<DiceSideType, SideScriptable> allSidesDict = new Dictionary<DiceSideType, SideScriptable>(); 
}
