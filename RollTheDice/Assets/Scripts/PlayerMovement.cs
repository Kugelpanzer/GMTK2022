using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : BaseMovement
{
    private float timeLerped = 0f;
    public float timeToLerp = 2f;


    // Start is called before the first frame update
    public void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public void Update()
    {
        base.Update();
    }

    void RotateTo(Vector3 to)
    {

        timeLerped += Time.deltaTime;
        transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to, timeLerped / timeToLerp);

    }
}
