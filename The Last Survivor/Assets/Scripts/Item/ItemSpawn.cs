using UnityEngine;

public class ItemSpawn : MonoBehaviour, ISpawnAction
{
    private float timer;
    private Pool itemSpawnPool;
    [SerializeField]
    private float spawnInterval = 3f;
    public bool IsActiveToSpawn { get; set; }

    private void Awake()
    {
        timer = spawnInterval;
        itemSpawnPool = GetComponent<Pool>();
        IsActiveToSpawn = true;
    }

    private void Update()
    {
        if (IsActiveToSpawn)
        {
            SetCountDown();
        }
    }

    private void SetCountDown()
    {
        spawnInterval -= Time.deltaTime;
        if (spawnInterval <= 0)
        {
            Spawn();
            spawnInterval = timer;
        }
    }

    public void Spawn()
    {
        int random = Random.Range(0, itemSpawnPool.InstantiatePrefabs.Length);
        itemSpawnPool.ChangePrefabStatus(random, true);
        IsActiveToSpawn = false;
    }
}
