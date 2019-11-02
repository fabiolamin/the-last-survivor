using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    [SerializeField]
    Health playerHealth;
    [SerializeField]
    Health enemyHealth;
    [SerializeField]
    AttackDamage bulletAttackDamage;
    [SerializeField]
    private float timeToFinishRound = 60f;
    [SerializeField]
    private int amountEnemyHealthToIncrease = 1;
    [SerializeField]
    private int amountBulletDamageToIncrease = 1;
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
            IncreaseEnemyHealth();
            IncreaseBulletAttackDamage();
        }

        Debug.Log("Round number: " + roundNumber + " || " + "Enemy health: " + enemyHealth.Value + " || " + "Bullet damage: " + bulletAttackDamage.Value);
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

    void IncreaseBulletAttackDamage()
    {
        bulletAttackDamage.Value += amountBulletDamageToIncrease;
    }

    void IncreaseEnemyHealth()
    {
        enemyHealth.Value += amountEnemyHealthToIncrease;
    }

    void IncreaseRoundNumber()
    {
        roundNumber++;
    }
}
