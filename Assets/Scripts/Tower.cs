using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform towerTop;    //Top of turret
    [SerializeField] Transform enemy;       //Enemy to look at
    [SerializeField] float range;           //The towers range 
    [SerializeField] ParticleSystem bullets;

    private void Start()
    {
    }

    // Update is called once per frame
    void Update ()
    {
        shootAtEnemy();
    }

    //Tower shoots at enemy when it comes within distance
    private void shootAtEnemy()
    {
        if (enemy != null && Vector3.Distance(enemy.position, transform.position) <= range)
        {
            towerTop.LookAt(enemy);
            if (!bullets.isPlaying)
            {
                bullets.Play();
            }
        }
        else
        {
            bullets.Stop();
        }
    }
}
