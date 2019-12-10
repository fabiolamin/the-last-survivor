using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectSpawn : MonoBehaviour
{
    private float timerAux;
    private Pool gameObjectSpawnPool;
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
        gameObjectSpawnPool = GetComponent<Pool>();
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
        if (position < gameObjectSpawnPool.InstantiatePrefabs.Length)
        {
            gameObjectSpawnPool.EnablePrefab(position);
            position++;
        }
    }
}
