using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{

    Dictionary<Vector3, Waypoint> path = new Dictionary<Vector3, Waypoint>();               //Stores all waypoints and their positions
    Waypoint[] waypoints;
    [SerializeField] Waypoint startCube;
    [SerializeField] Waypoint endCube;
    MeshRenderer topColor;
    Queue<Waypoint> queue = new Queue<Waypoint>();
    Waypoint currentCube;
    List<Waypoint> shortestPath = new List<Waypoint>();

    //public Waypoint[] getStartAndEndPoints()
    //{
    //    return new Waypoint[] { startCube, endCube };
    //}

    public List<Waypoint> getShortestPath()
    {
        if (shortestPath.Count == 0)
        {
            waypoints = FindObjectsOfType<Waypoint>();
            loadCubes();
            findPath();
            findPathToEnd();
            return shortestPath;
        }
        else
        {
            return shortestPath;
        }

    }

    //Puts all cubes in a dictionary and links to their position
    private void loadCubes()
    {
        foreach (Waypoint waypoint in waypoints)
        {
            if (!path.ContainsKey(waypoint.getCubePosition()) && waypoint.tag.ToLower() != "wallcube" && waypoint.tag.ToLower() != "turretcube")       //If there isn't a duplpicate waypoint
            {
                path.Add(waypoint.getCubePosition(), waypoint);
            }
        }
    }

    //Finds all paths from start cube to all other cubes
    private void findPath()
    {
        queue.Enqueue(startCube);

        while (queue.Count > 0)
        {
            currentCube = queue.Dequeue();
            currentCube.setIsExplored(true);

            if (currentCube == endCube)
            {
                break;
            }

            exploreNeighbors();
        }
    }

    //Given start cubes, calculate where each of neighbors should be located
    private void exploreNeighbors()
    {
        Vector3[] neighborPositions = {
                                        currentCube.getCubePosition() + Vector3.left,
                                        currentCube.getCubePosition() + Vector3.right,
                                        currentCube.getCubePosition() + Vector3.back,
                                        currentCube.getCubePosition() + Vector3.forward
                                      };

        checkIfNeighborExist(neighborPositions);
    }

    //Check if calculated neighbor position exist in path
    private void checkIfNeighborExist(Vector3[] neighbors)
    {
        foreach (Vector3 position in neighbors)
        {
            if (path.ContainsKey(position))
            {
                addCube(position);
            }
        }
    }

    //Add a new cube to the queue
    private void addCube(Vector3 position)
    {
        Waypoint cubeToAdd = path[position];

        if (!cubeToAdd.getIsExplored() && !queue.Contains(cubeToAdd))
        {
            queue.Enqueue(cubeToAdd);
            cubeToAdd.exploredFrom = currentCube;
        }
    }

    //Finds shortest path from start cube to end cube
    private void findPathToEnd()
    {
        Waypoint currentCube = endCube;

        while (currentCube != startCube)
        {
            shortestPath.Add(currentCube);
            currentCube = currentCube.exploredFrom;
        }

        shortestPath.Reverse();
    }
}