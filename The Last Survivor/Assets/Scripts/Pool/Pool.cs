using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    private GameObject prefab;
    [SerializeField]
    private GameObject[] prefabToInstantiate;
    [SerializeField]
    private int amountToInstantiate = 10;
    [SerializeField]
    private GameObject parentGameObject;

    public GameObject[] InstantiatePrefabs { get; private set; }

    private void Awake()
    {
        InstantiatePrefabs = new GameObject[amountToInstantiate];
        SetPrefabs();
    }

    private void SetPrefabs()
    {
        for (int position = 0; position < InstantiatePrefabs.Length; position++)
        {
            int random = Random.Range(0, prefabToInstantiate.Length);
            prefab = Instantiate(prefabToInstantiate[random], transform.position, Quaternion.identity);
            prefab.transform.SetParent(parentGameObject.transform);
            prefab.SetActive(false);
            InstantiatePrefabs[position] = prefab;
        }
    }

    public GameObject GetPrefab(int position)
    {
        ChangePrefabStatus(position, true);
        return prefab;
    }

    public void ChangePrefabStatus(int position, bool status)
    {
        prefab = InstantiatePrefabs[position];
        prefab.SetActive(status);
    }

    public void RecyclePrefabs()
    {
        for (int position = 0; position < InstantiatePrefabs.Length; position++)
        {
            ChangePrefabStatus(position, false);
            prefab.transform.position = transform.position;
        }
    }
}
