using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] List<Block> path;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(moveEnemy());
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    //Moves enemy along the blocks
    private IEnumerator moveEnemy()
    {
        foreach (Block waypoint in path)
        {
            transform.position = waypoint.transform.position;
            print("Visiting: " + waypoint.name);
            yield return new WaitForSeconds(1f);
        }
    }
}
