using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {

    Dictionary<Vector3, Waypoint> path = new Dictionary<Vector3, Waypoint>();
    Waypoint[] waypoints;

	// Use this for initialization
	void Start () {
        waypoints = FindObjectsOfType<Waypoint>();
        loadCubes();
	}

    //Puts all cubes in a dictionary and links to their position
    private void loadCubes()
    {
        foreach (Waypoint waypoint in waypoints)
        {
            if (!path.ContainsKey(waypoint.getCubePosition()))       //If there isn't a duplpicate waypoint
            {
                path.Add(waypoint.getCubePosition(), waypoint);
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
