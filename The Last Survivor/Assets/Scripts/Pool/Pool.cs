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
    private GameObject parentGameObject;

    public GameObject[] InstantiatePrefabs { get; private set; }

    private void Awake()
    {
        parentGameObject = gameObject;
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

    public void EnablePrefab(int position)
    {
        ChangePrefabStatus(position, true);
    }

    public void DisablePrefab(int position)
    {
        ChangePrefabStatus(position, false);
    }

    public void ChangePrefabStatus(int position, bool status)
    {
        prefab = InstantiatePrefabs[position];
        prefab.SetActive(status);
    }
}
