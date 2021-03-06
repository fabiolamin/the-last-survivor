﻿using System;
using UnityEngine;
using System.Linq;

public class Pool : MonoBehaviour
{
    private GameObject gamObject;
    [SerializeField]
    private GameObject[] gameObjectToInstantiate;
    [SerializeField]
    private int amountToInstantiate = 10;
    public GameObject[] InstantiatedGameObjects { get; private set; }
    public int AmountToInstantiate 
    {
        get{ return amountToInstantiate; }
        private set { amountToInstantiate = value; }
    }

    private void Awake()
    {
        InstantiatedGameObjects = new GameObject[amountToInstantiate];
        SetGameObjects();
    }

    private void SetGameObjects()
    {
        for (int position = 0; position < amountToInstantiate; position++)
        {
            int availablePosition = position % gameObjectToInstantiate.Length;
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
        if (!InstantiatedGameObjects[position].activeSelf)
        {
            InstantiatedGameObjects[position].SetActive(true);
        }
    }

    public void DisableGameObject(int position)
    {
        if (InstantiatedGameObjects[position].activeSelf)
        {
            InstantiatedGameObjects[position].SetActive(false);
        }
    }

    public void RecycleAllGameObjects()
    {
        foreach (GameObject gameObject in InstantiatedGameObjects)
        {
            gameObject.transform.position = transform.position;
        }
    }
}