using System.Collections;
using System.Collections.Generic;
using UnityEditor.Graphs;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    const int cubeMovementFactor = 10;       //Amount to move the cube by
    Vector3 cubePosition;                    //Current cube position
    
    


    // Use this for initialization
    void Start ()
    {
        cubePosition = gameObject.transform.position;
    }

   

    // Update is called once per frame
    void Update () {
	}

    
    public int getCubeMovementFactor()
    {
        return cubeMovementFactor;
    }

    
    public Vector3 getCubePosition()
    {
        cubePosition.x = Mathf.RoundToInt(transform.position.x / cubeMovementFactor);
        cubePosition.z = Mathf.RoundToInt(transform.position.z / cubeMovementFactor);
        return new Vector3(cubePosition.x, 0f, cubePosition.z);
    }


}
