using UnityEngine;
using System.Linq;

public class RoundManager : MonoBehaviour
{
    private float auxiliaryTimer;
    private int roundNumber;
    [SerializeField]
    private Pool[] enemySpawnsPools;
    [SerializeField]
    private Health playerHealth;
    [SerializeField]
    float amountEnemyAttackDamageToIncrease;
    [SerializeField]
    private float intervalToNextRound = 5f;

    private void Awake()
    {
        auxiliaryTimer = intervalToNextRound;
        roundNumber = 1;
    }

    private void Update()
    {
        if (enemySpawnsPools.All(enemySpawnPool => enemySpawnPool.AreAllGameObjectsDisabled()))
        {
            if (HasIntervalToNextRoundDone())
            {
                IncreaseRoundNumber();
                IncreaseEnemyAttackDamage();
                RestartEnemySpawns();
            }
        }
    }

    private bool HasIntervalToNextRoundDone()
    {
        intervalToNextRound -= Time.deltaTime;
        if (intervalToNextRound <= 0)
        {
            intervalToNextRound = auxiliaryTimer;
            return true;
        }
        return false;
    }

    private void IncreaseRoundNumber()
    {
        roundNumber++;
    }

    private void IncreaseEnemyAttackDamage()
    {
        foreach (Pool enemySpawnPool in enemySpawnsPools)
        {
            foreach (GameObject enemy in enemySpawnPool.InstantiatedGameObjects)
            {
                enemy.GetComponent<AttackDamage>().Change(amountEnemyAttackDamageToIncrease);
            }
        }
    }

    private void RestartEnemySpawns()
    {
        foreach (Pool enemySpawnPool in enemySpawnsPools)
        {
            enemySpawnPool.RecycleAllGameObjects();
        }
    }
}
