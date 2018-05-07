using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class SnapInEdit : MonoBehaviour
{

    [SerializeField] [Range(1f,20f)] float gridSize;  //Amount to move he cube by
    TextMesh cubeText;

    // Update is called once per frame
    void Update ()
    {
        snapCube();
    }

    //Moves cube every 'gridSize' units in x and z axis
    private void snapCube()
    {
        Vector3 cubePos;
        cubePos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        cubePos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
        transform.position = new Vector3(cubePos.x, 0f, cubePos.z);
        changeLabel(cubePos.x, cubePos.z);
    }

    //Changes the text to its current coordinates
    private void changeLabel(float xPos, float zPos)
    {
        cubeText = GetComponentInChildren<TextMesh>();
        cubeText.text = xPos / gridSize + "," + zPos / gridSize;
        gameObject.name = cubeText.text;
    }
}
