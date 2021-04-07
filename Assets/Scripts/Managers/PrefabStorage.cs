using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabStorage : MonoBehaviour
{
    public GameObject[] obstPrefabs;



    public GameObject GetRandomPrefab()
    {
        return obstPrefabs[Random.Range(0, obstPrefabs.Length)];
    }
}
