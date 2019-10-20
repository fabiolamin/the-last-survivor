using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private float spawnInterval = 1f;
    private float timerAux;

    private void Awake()
    {
        timerAux = spawnInterval;
    }
    private void Update()
    {
        spawnInterval -= Time.deltaTime;
        if (spawnInterval < 0)
        {
            Spawn();
            spawnInterval = timerAux;
        }
    }
    void Spawn()
    {
        Instantiate(enemy, transform.position, Quaternion.identity);
    }
}
