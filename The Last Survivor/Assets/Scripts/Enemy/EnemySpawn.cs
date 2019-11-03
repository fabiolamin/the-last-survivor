using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private float timerAux;
    [SerializeField]
    private float spawnInterval = 1f;
    [SerializeField]
    private GameObject enemy;
    [SerializeField]

    public float SpawnInterval
    {
        get{ return spawnInterval; }
        set{ spawnInterval = value; }
    }

    private void Awake()
    {
        timerAux = spawnInterval;
    }
    private void Update()
    {
        timerAux -= Time.deltaTime;
        if (timerAux < 0)
        {
            Spawn();
            timerAux = spawnInterval;
        }
    }
    void Spawn()
    {
        Instantiate(enemy, transform.position, Quaternion.identity);
    }
}
