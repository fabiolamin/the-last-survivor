using UnityEngine;

public class ItemSpawn : MonoBehaviour, ISpawnAction
{
    private float auxiliaryTimer;
    private Pool itemSpawnPool;
    [SerializeField]
    private float spawnInterval = 3f;
    public bool IsActiveToSpawn { get; set; }
    public ParticleSystem particle;

    private void Awake()
    {
        auxiliaryTimer = spawnInterval;
        itemSpawnPool = GetComponent<Pool>();
        IsActiveToSpawn = true;
    }

    private void Update()
    {
        if (IsActiveToSpawn)
        {
            if(HasSpawnIntervalDone())
            {
                Spawn();
            }
        }
    }

    private bool HasSpawnIntervalDone()
    {
        spawnInterval -= Time.deltaTime;
        if (spawnInterval <= 0)
        {
            spawnInterval = auxiliaryTimer;
            return true;
        }

        return false;
    }

    public void Spawn()
    {
        int random = Random.Range(0, itemSpawnPool.InstantiatedGameObjects.Length);
        itemSpawnPool.EnableGameObject(random);
        IsActiveToSpawn = false;
    }
}
