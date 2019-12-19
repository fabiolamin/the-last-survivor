using UnityEngine;

public class EnemySpawn : MonoBehaviour, ISpawnAction
{
    private int position;
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
        position = 0;
    }
    private void Update()
    {
        if (IsReadyToSpawn)
        {
            Spawn();
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
        if(position < enemySpawnPool.InstantiatedGameObjects.Length)
        {
            if (HasSpawnIntervalDone())
            {
                enemySpawnPool.EnableGameObject(position);
                position++;
            }
        }
        else
        {
            position = 0;
            IsReadyToSpawn = false;
        }
    }
}
