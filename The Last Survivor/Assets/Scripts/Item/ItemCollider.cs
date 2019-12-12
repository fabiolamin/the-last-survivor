using UnityEngine;

public class ItemCollider : MonoBehaviour
{
    private ItemSpawn itemSpawn;

    private void Awake()
    {
        itemSpawn = GameObject.FindGameObjectWithTag("ItemSpawn").GetComponent<ItemSpawn>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            itemSpawn.IsActiveToSpawn = true;
        }
    }
}
