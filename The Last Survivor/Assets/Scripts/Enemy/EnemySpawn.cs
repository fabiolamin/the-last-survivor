using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private float timerAux;
    private Pool enemySpawnPool;
    private int position;
    private GameObject enemy;
    [SerializeField]
    private float spawnInterval = 1f;

    public float SpawnInterval
    {
        get{ return spawnInterval; }
        set{ spawnInterval = value; }
    }

    private void Awake()
    {
        timerAux = spawnInterval;
        enemySpawnPool = GetComponent<Pool>();
        position = 0;
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
    private void Spawn()
    {
        if(position < enemySpawnPool.InstantiatePrefabs.Length)
        {
            enemySpawnPool.EnablePrefab(position);
            position++;
        }
    }
}
