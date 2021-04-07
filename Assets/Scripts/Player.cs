using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float steeringSpeed = .3f;
    public float accBreakSpeed = 1f;
    public float moveSpeed = 3;

    Camera cam;


    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        var xInput = Input.GetAxis("Horizontal");

        transform.position += (Vector3.right * xInput * steeringSpeed
            + Vector3.up * moveSpeed)
            * Time.deltaTime;

        var camPos = cam.transform.position;
        camPos.y = transform.position.y;
        cam.transform.position = camPos;
    }
}
