using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollider : MonoBehaviour
{
    [SerializeField]
    private ItemSpawn itemSpawn;

    private void OnTriggerEnter(Collider other)
    {
        itemSpawn.IsActiveToSpawn = other.gameObject.CompareTag("Player");
    }
}
