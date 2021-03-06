﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    [SerializeField] int health = 5;
    [SerializeField] ParticleSystem hitParticle;
    [SerializeField] ParticleSystem deathParticle;

    // Use this for initialization
    void Start ()
    {
    }

    private void OnParticleCollision(GameObject other)
    {
        takeDamage();
    }

    private void takeDamage()
    {
        health--;
        hitParticle.Play();

        if (health == 0)
        {
            Instantiate(deathParticle, transform.Find("Body").position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
