using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCube2 : MonoBehaviour
{
    [SerializeField] private GameObject cubeToSpawn;

    [SerializeField] private Transform[] waypoints;

    [SerializeField] private float timeBetweenSteps;

    private GameObject cube;
    private bool movementStarted;
    private float distance;
    private int actualWaypoint = 0;

    private bool canSpawnCube = true;


    private void OnMouseDown()
    {
        if (canSpawnCube)
        {
            canSpawnCube = false;
            cube = Instantiate(cubeToSpawn, transform.position, Quaternion.identity);
        }
    }


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

                if (actualWaypoint == waypoints.Length)
                {
                    Destroy(cube);
                    canSpawnCube = true;
                    actualWaypoint = 0;
                }
            }
        }
    }
}
