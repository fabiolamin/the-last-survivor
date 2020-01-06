using UnityEngine;
using System.Linq;

public class RoundController : MonoBehaviour
{
    [SerializeField]
    private UIStatus UIStatus;
    [SerializeField]
    private GameObject[] enemySpawns;
    [SerializeField]
    private Health playerHealth;
    [SerializeField]
    float amountEnemyAttackDamageToIncrease;
    [SerializeField]
    private float intervalToNextRound = 5f;

    public int RoundNumber { get; private set; }

    private void Awake()
    {
        RoundNumber = 1;
    }

    private void Update()
    {
        if (AreAllEnemiesDefeated())
        {
            SetNextRound();
        }

        if(IsPlayerDefeated())
        {
            UIStatus.IsGameOver = true;
        }
    }

    private bool IsPlayerDefeated()
    {
        return playerHealth.Amount <= 0;
    }

    private bool AreAllEnemiesDefeated()
    {
        return enemySpawns.All(enemySpawn => enemySpawn.GetComponent<Pool>().InstantiatedGameObjects.All(enemy => enemy.GetComponent<Health>().Amount <= 0));
    }

    private void SetNextRound()
    {
        IncreaseRoundNumber();
        IncreaseEnemyAttackDamage();
        RestartEnemyHealth();
        enemySpawns.ToList().ForEach(enemySpawn => enemySpawn.GetComponent<EnemySpawn>().Restart());
    }

    private void IncreaseRoundNumber()
    {
        RoundNumber++;
        if(RoundNumber > PlayerPrefs.GetInt("highround"))
        {
            PlayerPrefs.SetInt("highround", RoundNumber);
        }
    }

    private void IncreaseEnemyAttackDamage()
    {
        foreach (GameObject enemySpawn in enemySpawns)
        {
            foreach (GameObject enemy in enemySpawn.GetComponent<Pool>().InstantiatedGameObjects)
            {
                enemy.GetComponentInChildren<AttackDamage>().Change(amountEnemyAttackDamageToIncrease);
            }
        }
    }

    private void RestartEnemyHealth()
    {
        foreach (GameObject enemySpawn in enemySpawns)
        {
            foreach (GameObject enemy in enemySpawn.GetComponent<Pool>().InstantiatedGameObjects)
            {
                enemy.GetComponent<Health>().Restart();
            }
        }
    }
}
