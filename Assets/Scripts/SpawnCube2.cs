using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCube2 : MonoBehaviour
{
    [SerializeField] private GameObject cubeToSpawn;

    [SerializeField] private Transform[] waypoints;

    [SerializeField] private float timeBetweenSteps;

    private int steps = 0;

    private GameObject cube;
    private bool movementStarted;
    private float distance;
    private int actualWaypoint = 0;

    private void Update()
    {
        if (cube != null && actualWaypoint < waypoints.Length)
        {
            if (!movementStarted)
            {
                distance = Vector3.Distance(waypoints[actualWaypoint].position, cube.transform.position);
                movementStarted = true;
            }

            cube.transform.position += (waypoints[actualWaypoint].position - cube.transform.position).normalized
                                       * Time.deltaTime * distance / timeBetweenSteps;

            if (Vector3.Distance(waypoints[actualWaypoint].position, cube.transform.position) <= 0.01f)
            {
                actualWaypoint++;
                movementStarted = false;

                if (actualWaypoint == waypoints.Length) Destroy(cube);
            }
        }




    }




    private void OnMouseDown()
    {
        if (steps == 0)
        {
            cube = Instantiate(cubeToSpawn, transform.position, Quaternion.identity);
            steps++;
        }
    }







}
