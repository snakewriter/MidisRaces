using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float moveSpeed = 5f;


    void Update()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;
    }
}
