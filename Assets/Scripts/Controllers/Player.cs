using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager gameManager;
    public float steeringSpeed;
    public float accBrakeSpeed;
    public float moveSpeed;
    public bool gameover = false;

    Camera cam;


    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (gameover) return;

        var inputSteer = Input.GetAxis("Horizontal");

        transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        // ВрЕменный поворот в стороны
        transform.position += Vector3.right * steeringSpeed * inputSteer * Time.deltaTime;

        var camPosition = cam.transform.position;
        camPosition.y = transform.position.y;
        cam.transform.position = camPosition;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        gameManager.HandleCollision(collision.gameObject);
    }
}
