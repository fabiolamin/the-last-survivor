using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour, ISpawnAction
{
    private int position;
    private float auxiliaryTimer;
    private Pool enemySpawnPool;
    [SerializeField]
    private float spawnInterval = 1f;

    public float SpawnInterval
    {
        get { return spawnInterval; }
        set { spawnInterval = value; }
    }

    private void Awake()
    {
        position = 0;
        auxiliaryTimer = spawnInterval;
        enemySpawnPool = GetComponent<Pool>();
    }
    private void Update()
    {
        if (position < enemySpawnPool.InstantiatedGameObjects.Length)
        {
            if(HasSpawnIntervalDone())
            {
                Spawn();
            }
        }
    }

    private bool HasSpawnIntervalDone()
    {
        spawnInterval -= Time.deltaTime;
        if (spawnInterval < 0)
        {
            spawnInterval = auxiliaryTimer;
            return true;
        }

        return false;
    }

    public void Spawn()
    {
        enemySpawnPool.ChangeGameObjectStatus(position, true);
        position++;
    }
}
