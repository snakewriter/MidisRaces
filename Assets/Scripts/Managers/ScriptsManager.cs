using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptsManager : MonoBehaviour
{
    public float resetDistanceY;
    public int lines = 4;
    public float roadHeight = 6;
    public float[] roadLinesCentersX;

    SpawnManager spawnManager;
    PrefabStorage prefabStorage;


    public void SpawnObstacles(float roadLineCenterY)
    {
        spawnManager.SpawnObjects(roadLineCenterY);
    }


    void Start()
    {
        Road.manager = this;
        SpawnManager.manager = this;

        prefabStorage = GetComponent<PrefabStorage>(); // вытаскиваем скрипт из объекта на котором этот скрипт
        SpawnManager.prefabStorage = prefabStorage;
        
        spawnManager = new SpawnManager();  // создаем экземпляр класса                      
    }
}
