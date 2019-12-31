using UnityEngine;

public class ItemCollider : MonoBehaviour
{
    private ItemSpawn itemSpawn;
    private GameObject player;

    private void Awake()
    {
        itemSpawn = GameObject.FindGameObjectWithTag("ItemSpawn").GetComponent<ItemSpawn>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            itemSpawn.particle.Play();
            player = other.gameObject;
            gameObject.SetActive(false);
            Verify(gameObject.tag);
            itemSpawn.IsActiveToSpawn = true;
        }
    }

    private void Verify(string tag)
    {
        switch (tag)
        {
            case "Health":
                player.GetComponent<Health>().Change(10);
                break;
            case "Ammo":
                player.GetComponentInChildren<Ammo>().Change(5);
                break;
        }
    }
}
