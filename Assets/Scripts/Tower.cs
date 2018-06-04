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

            foreach (EnemyDamage enemy in enemies)
            {
                closestEnemy = getClosestEnemy(closestEnemy, enemy.transform);
            }

            this.enemy = closestEnemy;
        }
    }

    private Transform getClosestEnemy(Transform closestEnemy, Transform otherEnemy)
    {
        float distanceFromClosest = Vector3.Distance(closestEnemy.position, transform.position);
        float distanceFromOther = Vector3.Distance(otherEnemy.position, transform.position);

        if (distanceFromClosest < distanceFromOther)
        {
            return closestEnemy;
        }
        else
        {
            return otherEnemy;
        }
    }

    //Tower shoots at enemy when it comes within distance
    private void shootAtEnemy()
    {
        if (enemy != null && Vector3.Distance(enemy.position, transform.position) <= range)
        {
            towerTop.LookAt(enemy.transform.Find("Body"));

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
