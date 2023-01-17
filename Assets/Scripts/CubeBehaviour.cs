using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{
    private bool changeScale;
    private float scaleSpeed;
    private Vector3 initialScale;
    private Vector3 targetScale;

    private void Start()
    {
        initialScale = transform.localScale;
    }


    private void Update()
    {
        if (changeScale)
        {
            transform.localScale = Vector3.Lerp(initialScale, targetScale, Time.deltaTime * scaleSpeed);

            if (transform.localScale == targetScale) changeScale = false;
        }
    }


    public void ChangeScale(float scale, float speed)
    {
        Debug.Log("Scale change factor " + scale + " on " + speed + " seconds.");
        scaleSpeed = speed;
        targetScale = new Vector3(scale, scale, scale);
        initialScale = transform.localScale;
        changeScale = true;
    }
}
