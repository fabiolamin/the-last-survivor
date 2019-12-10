using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    [SerializeField]
    private Health playerHealth;
    [SerializeField]
    private AttackDamage[] enemiesAttackDamage;
    [SerializeField]
    float amountEnemyAttackDamageToIncrease;
    [SerializeField]
    private float timeToFinishRound = 60f;
    private int roundNumber;
    private float timerAux;
    
    private void Awake()
    {
        roundNumber = 1;
        timerAux = timeToFinishRound;
    }

    private void Update()
    {
        if (SetTimerToChangeRound())
        {
            IncreaseRoundNumber();
            IncreaseEnemyAttackDamage();
        }
    }

    private bool SetTimerToChangeRound()
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

    private void IncreaseEnemyAttackDamage()
    {
        //ToDo
    }
}
