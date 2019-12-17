using UnityEngine;

public class RoundManager : MonoBehaviour
{
    private int roundNumber;
    private float timerAux;
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
        timerAux = timeToFinishRound;
    }

    private void Update()
    {
        if (HasRoundChanged())
        {
            IncreaseRoundNumber();
            IncreaseEnemyAttackDamage();
            RestartEnemySpawns();
        }
    }

    private bool HasRoundChanged()
    {
        timeToFinishRound -= Time.deltaTime;
        if (timeToFinishRound < 0)
        {
            if (playerHealth.Value > 0)
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
