using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private float gizmosRadius;
    [SerializeField] private bool changeScale;
    [SerializeField] private float factor = 1;
    [SerializeField] private float speed = 1;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, gizmosRadius);
    }



    private void OnTriggerEnter(Collider other)
    {
        if (changeScale) other.GetComponent<CubeBehaviour>().ChangeScale(factor, speed);
    }

}
