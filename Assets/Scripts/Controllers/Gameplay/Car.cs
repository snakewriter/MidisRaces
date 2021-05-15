using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float moveSpeed = 3f;


    void Update()
    {
        transform.position += new Vector3(0, moveSpeed) * Time.deltaTime;
    }
}
