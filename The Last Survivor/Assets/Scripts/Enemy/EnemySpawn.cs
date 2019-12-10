using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour, ISpawnAction
{
    private float timerAux;
    private Pool enemySpawnPool;
    private int position;
    [SerializeField]
    private float spawnInterval = 1f;

    public float SpawnInterval
    {
        get { return spawnInterval; }
        set { spawnInterval = value; }
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

    public void Spawn()
    {
        if (position < enemySpawnPool.InstantiatePrefabs.Length)
        {
            enemySpawnPool.EnablePrefab(position);
            position++;
        }
    }
}
