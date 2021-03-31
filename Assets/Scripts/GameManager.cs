using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float[] linesCentersX;
    public GameObject[] obstPrefabs;

    public float resetDistanceY;
    public int lines;


    public GameObject GetObstacle()
    {
        return obstPrefabs[Random.Range(0, obstPrefabs.Length)];
    }

    void Start()
    {
        Road.SetManager(this);
    }
}
