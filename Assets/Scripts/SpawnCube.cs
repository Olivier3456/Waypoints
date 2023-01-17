using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCube : MonoBehaviour
{
    [SerializeField] private GameObject cubeToSpawn;

    [SerializeField] private Transform[] waypoints;

    [SerializeField] private float poseTime;

    private int steps = 0;

    private GameObject cube;

    private bool canSpawnCube = true;

    private void OnMouseDown()
    {
        if (canSpawnCube)
        {
            canSpawnCube = false;
            cube = Instantiate(cubeToSpawn, waypoints[0].position, Quaternion.identity);
            
            StartCoroutine(MoveCube());
        }
    }


    private IEnumerator MoveCube()
    {
        yield return new WaitForSeconds(poseTime);
        steps++;

        if (steps < waypoints.Length)
        {
            cube.transform.position = waypoints[steps].position;
            StartCoroutine(MoveCube());
        }
        else
        {
            Destroy(cube);
            steps = -1;
            canSpawnCube = true;
        }
    }
}
