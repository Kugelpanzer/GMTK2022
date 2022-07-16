using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public GameObject prevRot;
    public float speed = 2f;
    public float time = 2f;
    public float currTime = 0f;
    Quaternion to = new Quaternion();
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (currTime >= time / 2)
            {
                currTime = 0;
                to = Quaternion.AngleAxis(90, Vector3.forward);
                to *= transform.rotation;
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (currTime >= time / 2)
            {
                currTime = 0;
                to = Quaternion.AngleAxis(90, Vector3.right);
                to *= transform.rotation;
            }


            //to = Quaternion.FromToRotation(prevRot.transform.up, prevRot.transform.forward);

            Debug.Log(to);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {

            if (currTime >= time / 2)
            {
                currTime = 0;
                to = Quaternion.AngleAxis(-90, Vector3.forward);
                to *= transform.rotation;
            }


            //to = Quaternion.FromToRotation(prevRot.transform.up, prevRot.transform.right);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (currTime >= time / 2)
            {
                currTime = 0;
                to = Quaternion.AngleAxis(-90, Vector3.right);
                to *= transform.rotation;
            }


            //to = Quaternion.FromToRotation(prevRot.transform.up, -prevRot.transform.forward);
        }

        RotateOne(to);
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
