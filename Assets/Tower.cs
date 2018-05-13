using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform towerTop;    //Top of turret
    [SerializeField] Transform enemy;       //Enemy to look at
    
	
	// Update is called once per frame
	void Update ()
    {
        towerTop.LookAt(enemy);
	}
}
