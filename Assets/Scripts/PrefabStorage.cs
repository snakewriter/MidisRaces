using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabStorage : MonoBehaviour
{
    public GameObject[] prefabs;


    public GameObject GetRandomPrefab()
    {
        return prefabs[Random.Range(0, prefabs.Length - 1)];
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
