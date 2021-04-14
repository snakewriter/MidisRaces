using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptsManager : MonoBehaviour
{
    public float[] linesCentersX;
    public float roadHeight = 6;
    public float resetDistanceY;
    public int lines;

    SpawnManager spawnManager;
    PrefabStorage prefabStorage;


    
    public void SpawnObstacles(float spawnCenterY)
    {
        spawnManager.SpawnObjects(spawnCenterY);
    }



    void Start()
    {
        spawnManager = new SpawnManager();
        prefabStorage = GetComponent<PrefabStorage>();

        Road.manager = this;
        SpawnManager.manager = this;
        SpawnManager.prefabStorage = prefabStorage;
    }
}
