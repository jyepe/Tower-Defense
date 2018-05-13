using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
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
        //changeLabel();
    }

    //Moves cube every 'gridSize' units in x and z axis
    private void snapCube()
    {
        int cubeMovementFactor = waypoint.getCubeMovementFactor();
        Vector3 cubePosition = waypoint.getCubePosition() * cubeMovementFactor;

        transform.position = new Vector3(cubePosition.x, 0f, cubePosition.z);
    }

    //Changes the text to its current coordinates
    private void changeLabel()
    {
        cubeText = GetComponentInChildren<TextMesh>();
        Vector3 cubePosition = waypoint.getCubePosition();
        cubeText.text = cubePosition.x + "," + cubePosition.z;
        gameObject.name = cubeText.text;
    }
}
