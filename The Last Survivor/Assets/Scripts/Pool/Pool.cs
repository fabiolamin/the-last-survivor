﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pool : MonoBehaviour
{
    private GameObject gamObject;
    [SerializeField]
    private GameObject[] gameObjectToInstantiate;
    [SerializeField]
    private int amountToInstantiate = 10;

    public GameObject[] InstantiatedGameObjects { get; private set; }

    private void Awake()
    {
        InstantiatedGameObjects = new GameObject[amountToInstantiate];
        SetGameObjects();
    }

    private void SetGameObjects()
    {
        for (int position = 0; position < amountToInstantiate; position++)
        {
            int availablePosition = position  % gameObjectToInstantiate.Length;
            gamObject = Instantiate(gameObjectToInstantiate[availablePosition], transform.position, Quaternion.identity);
            gamObject.transform.SetParent(transform);
            gamObject.SetActive(false);
            InstantiatedGameObjects[position] = gamObject;
        }
    }

    public GameObject GetGameObject(int position)
    {
        return InstantiatedGameObjects[position];
    }

    public void EnableGameObject(int position)
    {
        ChangeGameObjectStatus(position, true);
    }

    public void DisableGameObject(int position)
    {
        ChangeGameObjectStatus(position, false);
    }

    public void ChangeGameObjectStatus(int position, bool status)
    {
        InstantiatedGameObjects[position].SetActive(status);
    }

}