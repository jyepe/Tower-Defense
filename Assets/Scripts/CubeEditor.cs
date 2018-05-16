using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    TextMesh cubeText;
    Waypoint waypoint;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    // Update is called once per frame
    void Update ()
    {
        snapCube();
    }

    //Moves cube every 'gridSize' units in x and z axis
    private void snapCube()
    {
        int cubeMovementFactor = waypoint.getCubeMovementFactor();
        Vector3 cubePosition = waypoint.getCubePosition() * cubeMovementFactor;

        transform.position = new Vector3(cubePosition.x, 0f, cubePosition.z);
    }
}
