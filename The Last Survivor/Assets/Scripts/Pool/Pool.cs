using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    private GameObject gamObject;
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
            gamObject = Instantiate(prefabToInstantiate[random], transform.position, Quaternion.identity);
            gamObject.transform.SetParent(parentGameObject.transform);
            gamObject.SetActive(false);
            InstantiatePrefabs[position] = gamObject;
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
        gamObject = InstantiatePrefabs[position];
        gamObject.SetActive(status);
    }
}
