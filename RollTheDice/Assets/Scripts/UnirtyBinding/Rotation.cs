using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GMTK2020;
public class Rotation : MonoBehaviour
{
    public GameObject prevRot;
    public float time = 2f;
    public float currTime = 0f;
    Quaternion to = new Quaternion();
    void Update()
    {


        RotateOne(to);
    }

    public bool CanMove()
    {
        if (currTime >= time / 2) return true;
        else return false;
    }//k == key.a
    public void Rotate(key k)
    {
        if (k == key.a)
        {
            if (currTime >= time / 2)
            {
                currTime = 0;
                to = Quaternion.AngleAxis(90, Vector3.forward);
                to *= transform.rotation;
            }
        }
        if (k == key.w)
        {
            if (currTime >= time / 2)
            {
                currTime = 0;
                to = Quaternion.AngleAxis(90, Vector3.right);
                to *= transform.rotation;
            }


            //to = Quaternion.FromToRotation(prevRot.transform.up, prevRot.transform.forward);

        }
        if (k == key.d)
        {

            if (currTime >= time / 2)
            {
                currTime = 0;
                to = Quaternion.AngleAxis(-90, Vector3.forward);
                to *= transform.rotation;
            }


            //to = Quaternion.FromToRotation(prevRot.transform.up, prevRot.transform.right);
        }
        if (k == key.s)
        {
            if (currTime >= time / 2)
            {
                currTime = 0;
                to = Quaternion.AngleAxis(-90, Vector3.right);
                to *= transform.rotation;
            }


            //to = Quaternion.FromToRotation(prevRot.transform.up, -prevRot.transform.forward);
        }
    }

    void RotateOne(Quaternion to)
    {


        if (currTime <= time / 2)
        {
            currTime += Time.deltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, to, currTime / time);
        }


    }
}
