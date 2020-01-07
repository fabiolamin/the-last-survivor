using UnityEngine;

public class ItemSpawn : MonoBehaviour, ISpawnAction
{
    private int count;
    private float auxiliaryTimer;
    private Pool Pool;
    [SerializeField]
    private float spawnInterval = 3f;
    public bool IsActiveToSpawn { get; set; }
    public ParticleSystem Particle{ get; private set; }
    public AudioSource AudioSource { get; private set; }

    private void Awake()
    {
        count = 0;
        auxiliaryTimer = spawnInterval;
        Pool = GetComponent<Pool>();
        IsActiveToSpawn = true;
        AudioSource = GetComponent<AudioSource>();
        Particle = GetComponentInChildren<ParticleSystem>();
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
        int position = count % Pool.InstantiatedGameObjects.Length;
        Pool.EnableGameObject(position);
        IsActiveToSpawn = false;
        count++;
    }
}
