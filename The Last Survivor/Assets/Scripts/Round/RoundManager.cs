using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    [SerializeField]
    Health playerHealth;
    [SerializeField]
    EnemySpawn[] enemySpawns;
    [SerializeField]
    float amountSpawnEnemyTimeToDecrease;
    [SerializeField]
    private float timeToFinishRound = 60f;
    private int roundNumber;
    private float timerAux;
    
    void Awake()
    {
        roundNumber = 1;
        timerAux = timeToFinishRound;
    }

    void Update()
    {
        if (SetTimerToChangeRound())
        {
            IncreaseRoundNumber();
            DecreaseEnemySpawnInterval();
        }
    }

    bool SetTimerToChangeRound()
    {
        timeToFinishRound -= Time.deltaTime;
        if(timeToFinishRound < 0)
        {
            if(playerHealth.Value > 0)
            {
                timeToFinishRound = timerAux;
                return true;
            }
        }
        return false;
    }

    void IncreaseRoundNumber()
    {
        roundNumber++;
    }

    void DecreaseEnemySpawnInterval()
    {
        foreach(EnemySpawn enemySpawn in enemySpawns)
        {
            if(enemySpawn.SpawnInterval > 0)
            {
                enemySpawn.SpawnInterval -= amountSpawnEnemyTimeToDecrease;
            }
        }
    }
}
