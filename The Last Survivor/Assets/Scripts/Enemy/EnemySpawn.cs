using UnityEngine;

public class EnemySpawn : MonoBehaviour, ISpawnAction
{
    private float auxiliaryTimer;
    private Pool enemySpawnPool;
    [SerializeField]
    private float spawnInterval = 1f;
    public bool IsReadyToSpawn { get; set; }
    public float SpawnInterval
    {
        get { return spawnInterval; }
        set { spawnInterval = value; }
    }

    private void Awake()
    {
        auxiliaryTimer = spawnInterval;
        enemySpawnPool = GetComponent<Pool>();
        IsReadyToSpawn = true;
    }
    private void Update()
    {
        if (IsReadyToSpawn)
        {
            Spawn();
            IsReadyToSpawn = false;
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

    public void Spawn()
    {
        for (int position = 0; position < enemySpawnPool.InstantiatedGameObjects.Length; position++)
        {
            if (HasSpawnIntervalDone())
            {
                enemySpawnPool.EnableGameObject(position);
            }
        }
    }
}
