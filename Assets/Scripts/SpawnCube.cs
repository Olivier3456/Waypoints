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



    private void OnMouseDown()
    {
        if (steps == 0)
        {
            cube = Instantiate(cubeToSpawn, waypoints[0].position, Quaternion.identity);
            steps++;
            StartCoroutine(MoveCube());
        }
    }


    private IEnumerator MoveCube()
    {
        yield return new WaitForSeconds(poseTime);

        cube.transform.position = waypoints[1].position;

        yield return new WaitForSeconds(poseTime);

        cube.transform.position = waypoints[2].position;

        yield return new WaitForSeconds(poseTime);

        steps = 0;
        Destroy(cube);
    }


}
