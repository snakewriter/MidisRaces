using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabStorage : MonoBehaviour
{
    public GameObject[] itemsPrefabs;
    public GameObject[] carsPrefabs;



    public GameObject GetRandomPrefab()
    {
        var prefab = itemsPrefabs[Random.Range(0, itemsPrefabs.Length)];
        if (prefab.tag != "Car") return prefab; // Если это не машинка - возвращаем сразу
        return carsPrefabs[Random.Range(0, carsPrefabs.Length)]; // Иначе берем произвольную машинку
    }
}
