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
