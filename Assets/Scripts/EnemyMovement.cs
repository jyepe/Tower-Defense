using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Graphs;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    PathFinder path;

    // Use this for initialization
    void Start()
    {
        path = FindObjectOfType<PathFinder>();
        StartCoroutine(moveEnemy(path.getShortestPath()));
    }

    //Moves enemy along the cubes
    private IEnumerator moveEnemy(List<Waypoint> shortestPath)
    {
        for (int i = 0; i < shortestPath.Count; i++)
        {
            float xPosition = shortestPath[i].transform.position.x;
            float zPosition = shortestPath[i].transform.position.z;
            transform.position = new Vector3(xPosition, transform.position.y, zPosition);
            yield return new WaitForSeconds(1f);
        }
    }
}