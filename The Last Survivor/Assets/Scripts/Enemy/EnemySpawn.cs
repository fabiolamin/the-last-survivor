using UnityEngine;
using System.Linq;

public class EnemySpawn : MonoBehaviour, ISpawnAction
{
    private int position;
    private float auxiliaryTimer;
    [SerializeField]
    float amountAttackDamageToIncrease;
    [SerializeField]
    private float spawnInterval = 1f;
    public bool IsReadyToSpawn { get; set; }
    public float SpawnInterval
    {
        get { return spawnInterval; }
        set { spawnInterval = value; }
    }

    public Pool Pool { get; private set; }
    public int EnemiesAmount { get; private set; }

    private void Awake()
    {
        auxiliaryTimer = spawnInterval;
        Pool = GetComponent<Pool>();
        IsReadyToSpawn = true;
        position = 0;
        EnemiesAmount = Pool.InstantiatedGameObjects.Length;
    }
    private void Update()
    {
        if (IsReadyToSpawn)
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        if (position < Pool.InstantiatedGameObjects.Length)
        {
            if (HasSpawnIntervalDone())
            {
                Pool.EnableGameObject(position);
                position++;
            }
        }
        else
        {
            IsReadyToSpawn = false;
            position = 0;
        }
    }

    private bool HasSpawnIntervalDone()
    {
        spawnInterval -= Time.deltaTime;
        if (spawnInterval < 0)
        {
            spawnInterval = auxiliaryTimer;
            return true;
        }

        return false;
    }

    public void IncreaseAttackDamage()
    {
        foreach (GameObject enemy in Pool.InstantiatedGameObjects)
        {
            enemy.GetComponentInChildren<AttackDamage>().Change(amountAttackDamageToIncrease);
        }
    }

    public void RestartHealth()
    {
        foreach (GameObject enemy in Pool.InstantiatedGameObjects)
        {
            enemy.GetComponent<Health>().Restart();
        }
    }

    public void Restart()
    {
        IsReadyToSpawn = true;
        Pool.RecycleAllGameObjects();
    }
}
