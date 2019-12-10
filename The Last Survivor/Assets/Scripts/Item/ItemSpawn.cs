using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    private float timer;
    [SerializeField]
    private GameObject[] items;
    [SerializeField]
    private float spawnInterval = 3f;
    public bool IsActiveToSpawn { get; set; }

    private void Awake()
    {
        timer = spawnInterval;
        IsActiveToSpawn = true;
    }

    private void Update()
    {
        spawnInterval -= Time.deltaTime;
        if(spawnInterval <= 0)
        {
            Spawn();
            spawnInterval = timer;
        }
    }

    private void Spawn()
    {
        if(IsActiveToSpawn)
        {
            int random = Random.Range(0, items.Length);
            items[random].SetActive(true);
        }
    }
}
