using UnityEngine;
using System.Linq;

public class RoundManager : MonoBehaviour
{
    private int roundNumber;
    [SerializeField]
    private Pool[] enemySpawnsPools;
    [SerializeField]
    private Health playerHealth;
    [SerializeField]
    float amountEnemyAttackDamageToIncrease;
    [SerializeField]
    private float timeToFinishRound = 60f;

    private void Awake()
    {
        roundNumber = 1;
    }

    private void Update()
    {
        if (enemySpawnsPools.All(enemySpawnPool => enemySpawnPool.AreAllGameObjectsDisabled()))
        {
            IncreaseRoundNumber();
            IncreaseEnemyAttackDamage();
            RestartEnemySpawns();
        }
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
        foreach(Pool enemySpawnPool in enemySpawnsPools)
        {
            enemySpawnPool.RecycleAllGameObjects();
        }
    }
}
