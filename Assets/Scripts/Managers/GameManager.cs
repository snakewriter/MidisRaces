using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] obsPrefabs;
    public float[] linesCentersX;
    public float roadHeight = 6;
    public float roadResetDisY;
    public float roadResetShift;
    public int lines = 4;


    public GameObject GetObstacle()
    {
        return obsPrefabs[Random.Range(0, obsPrefabs.Length)];
    }

    void Start()
    {
        Road.SetManager(this);
    }

    void Update()
    {
        
    }
}
