using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRotation : MonoBehaviour
{
    private int pendingRotations;
    private bool isRotating;
    public float speed = 2f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pendingRotations++;
            if (!isRotating) StartCoroutine(RotateRoutine());
        }
    }

    IEnumerator RotateRoutine()
    {
        // just in case
        if (isRotating) yield break;
        isRotating = true;

        var targetRotation = transform.rotation * Quaternion.Euler(0, 0, 90);

        while (transform.rotation != targetRotation)
        {
            transform.rotation = Quaternion.RotateTowards(startRotation, targetRotation, speed * Time.deltaTime);

            // tells Unity to "pause" the routine here, render this frame
            // and continue from here in the next fame
            yield return null;
        }

        // in order to end up with a clean value
        transform.rotation = targetRotation;

        isRotating = false;
        pendingRotations--;

        // are there more rotations pending?
        if (pendingRotations > 0)
        {
            // start another routine
            StartCoroutine(RotateRoutine());
        }
    }
}
