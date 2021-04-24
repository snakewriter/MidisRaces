using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabStorage : MonoBehaviour
{
    public GameObject[] items;
    public GameObject[] cars;



    public GameObject GetRandomPrefab()
    {
        var prefab = items[Random.Range(0, items.Length)]; // получаем любой префаб в переменную
        if (prefab.tag != "Car") return prefab; // это предмет - сразу возвращаем
        return cars[Random.Range(0, cars.Length)]; // это машинка - подбираем машинку
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
