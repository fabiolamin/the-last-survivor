using UnityEngine;
using System.Linq;

public class RoundController : MonoBehaviour
{
    [SerializeField]
    private UIStatus UIStatus;
    [SerializeField]
    private EnemySpawn[] enemySpawns;
    [SerializeField]
    private Health playerHealth;
    [SerializeField]
    private float intervalToNextRound = 5f;
    public int DefeatedsEnemies { get; set; }
    public int RoundNumber { get; private set; }

    private void Awake()
    {
        RoundNumber = 1;
        DefeatedsEnemies = 0; 
    }

    private void Update()
    {
        if(DefeatedsEnemies == (enemySpawns[0].EnemiesAmount * 2))
        {
            SetNextRound();
            DefeatedsEnemies = 0;
        }

        if (IsPlayerDefeated())
        {
            UIStatus.SetGameOver();
        }
    }

    private bool IsPlayerDefeated()
    {
        return playerHealth.Amount <= 0;
    }

    private void SetNextRound()
    {
        IncreaseRoundNumber();
        enemySpawns.ToList().ForEach(enemySpawn => enemySpawn.IncreaseAttackDamage());
        enemySpawns.ToList().ForEach(enemySpawn => enemySpawn.RestartHealth());
        enemySpawns.ToList().ForEach(enemySpawn => enemySpawn.Restart());
    }

    private void IncreaseRoundNumber()
    {
        RoundNumber++;
        if (RoundNumber > PlayerPrefs.GetInt("highround"))
        {
            PlayerPrefs.SetInt("highround", RoundNumber);
        }

        UIStatus.HasChanged = true;
    }
}
