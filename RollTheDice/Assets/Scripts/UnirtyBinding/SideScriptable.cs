using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GMTK2020;


[CreateAssetMenu(fileName ="New SideScript", menuName = "SideScript")]
public class SideScriptable : ScriptableObject
{
    public GameObject side3DPrefab;
    public GameObject sideUIPrefab;
    public GameObject effectPrefab;
    public DiceSideType type;
}
