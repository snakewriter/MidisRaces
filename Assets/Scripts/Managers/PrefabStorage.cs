using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabStorage : MonoBehaviour
{
    public GameObject[] obstPrefabs;
    public GameObject[] carsPrefabs;


    public GameObject GetRandomPrefab()
    {
        var prefab = obstPrefabs[Random.Range(0, obstPrefabs.Length)]; // Берем произвольный префаб
        if (prefab.tag != "Car") return prefab; // Если это не машинка - сразу возвращаем
        return carsPrefabs[Random.Range(0, carsPrefabs.Length)]; // Если машинка - берем одну из многих
    }
}
