using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SnapInEdit : MonoBehaviour
{

    [SerializeField] [Range(1f,20f)] float gridSize;  //Size of playing field

	// Update is called once per frame
	void Update ()
    {
        snapCube();
        checkBoundaries();
    }

    //Moves cube every 10 units in x and z axis
    private void snapCube()
    {
        Vector3 cubePos;
        cubePos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        cubePos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
        transform.position = new Vector3(cubePos.x, 0f, cubePos.z);
    }

    //Does not allow cubes to go out of gridsize
    private void checkBoundaries()
    {
        if (transform.position.x > gridSize)
        {
            transform.position = new Vector3(gridSize, 0f, transform.position.z);
        }
        else if (transform.position.x < -gridSize)
        {
            transform.position = new Vector3(-gridSize, 0f, transform.position.z);
        }
        if (transform.position.z > gridSize)
        {
            transform.position = new Vector3(transform.position.x, 0f, gridSize);
        }
        else if (transform.position.z < -gridSize)
        {
            transform.position = new Vector3(transform.position.x, 0f, -gridSize);
        }
    }
}
