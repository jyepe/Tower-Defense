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
    }

    //Moves cube every 'gridSize' units in x and z axis
    private void snapCube()
    {
        int cubeMovementFactor = waypoint.getCubeMovementFactor();
        Vector3 cubePosition = waypoint.getCubePosition();

        transform.position = new Vector3(cubePosition.x, 0f, cubePosition.z);
        changeLabel(cubePosition.x, cubePosition.z, cubeMovementFactor);
    }

    //Changes the text to its current coordinates
    private void changeLabel(float xPos, float zPos, int movementFactor)
    {
        cubeText = GetComponentInChildren<TextMesh>();
        cubeText.text = xPos / movementFactor + "," + zPos / movementFactor;
        gameObject.name = cubeText.text;
    }
}
