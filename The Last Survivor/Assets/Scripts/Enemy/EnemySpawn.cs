using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private float timerAux;
    [SerializeField]
    private float spawnInterval = 1f;
    [SerializeField]
    private GameObject[] enemies;

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
        int random = Random.Range(0, enemies.Length);
        Instantiate(enemies[random], transform.position, Quaternion.identity);
    }
}
