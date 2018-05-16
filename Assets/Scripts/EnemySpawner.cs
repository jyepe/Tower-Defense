using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(1f, 12f)] [SerializeField] float spawnTime;
    [SerializeField] EnemyMovement enemy;

    // Use this for initialization
    void Start ()
    {
        print("position of " + gameObject.name + " " + gameObject.transform.position);
        StartCoroutine(spawnEnemy());
	}

    private IEnumerator spawnEnemy()
    {
        while (true)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
