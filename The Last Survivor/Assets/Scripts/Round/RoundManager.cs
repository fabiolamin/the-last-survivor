using UnityEngine;
using System.Linq;

public class RoundManager : MonoBehaviour
{
    private float auxiliaryTimer;
    private int roundNumber;
    [SerializeField]
    private GameObject[] enemySpawns;
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
        if (enemySpawns.All(enemySpawn => enemySpawn.GetComponent<Pool>().AreAllGameObjectsDisabled()))
        {
            if (HasIntervalToNextRoundDone())
            {
                IncreaseRoundNumber();
                IncreaseEnemyAttackDamage();
                RestartEnemySpawns();
                enemySpawns.Select(enemySpawn => enemySpawn.GetComponent<EnemySpawn>().IsReadyToSpawn = true);
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
        foreach (GameObject enemySpawn in enemySpawns)
        {
            foreach (GameObject enemy in enemySpawn.GetComponent<Pool>().InstantiatedGameObjects)
            {
                enemy.GetComponent<AttackDamage>().Change(amountEnemyAttackDamageToIncrease);
            }
        }
    }

    private void RestartEnemySpawns()
    {
        foreach (GameObject enemySpawn in enemySpawns)
        {
            enemySpawn.GetComponent<Pool>().RecycleAllGameObjects();
        }
    }
}
