using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GMTK2020;
public class GenerateSides : MonoBehaviour
{
    public List<DiceSideType> sides = new List<DiceSideType>(6);


    public List<GameObject> sideObject = new List<GameObject>(6);

    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
        foreach(DiceSideType s in sides)
        {

            GameObject so = Instantiate(DataController.Instance.allSidesDict[s].side3DPrefab);
            sideObject.Add(so);
            so.transform.position = transform.position;
            so.transform.parent = transform;
            switch (i)
            {
                case 1:
                    so.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
                    break;
                case 2:
                    so.transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));
                    break;
                case 3:
                    so.transform.rotation = Quaternion.Euler(new Vector3(-90, 0, 0));
                    break;
                case 4:
                    so.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
                    break;
                case 5:
                    so.transform.rotation = Quaternion.Euler(new Vector3(180, 0, 0));
                    break;
            }
            i++;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
