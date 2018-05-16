using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform towerTop;    //Top of turret
    Transform enemy;                        //Enemy to look at
    [SerializeField] float range;           //The towers range 
    [SerializeField] ParticleSystem bullets;
    

    private void Start()
    {
    }

    // Update is called once per frame
    void Update ()
    {
        setEnemy();
        shootAtEnemy();
    }

    private void setEnemy()
    {
        EnemyDamage[] enemies = FindObjectsOfType<EnemyDamage>();

        if (enemies.Length != 0)
        {
            Transform closestEnemy = enemies[0].transform;
            enemy = closestEnemy;
        }
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
