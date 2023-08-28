using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : Behaviour
{
    private bool isRotating = false;
    private Vector3 targetRotation;
    private float rotationTime;

    public Vector3 axis;
    public float angle;
    public float time;

    public override void Do()
    {
        if (!isRotating)
        {
            targetRotation = transform.rotation.eulerAngles + axis * angle;
            rotationTime = time;
            StartCoroutine(RotateCoroutine());
        }
    }

    private System.Collections.IEnumerator RotateCoroutine()
    {
        isRotating = true;

        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(targetRotation);

        float elapsedTime = 0f;
        while (elapsedTime < rotationTime)
        {
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, elapsedTime / rotationTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = endRotation;
        isRotating = false;
    }


}
