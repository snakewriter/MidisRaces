using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager gameManager;
    public float steeringSpeed = 0.3f;
    public float gasBrakeSpeed = 1f;
    public float moveSpeed = 3f;

    Camera cam;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        var xInput = Input.GetAxis("Horizontal");
        var yInput = Input.GetAxis("Vertical");

        transform.position += (Vector3.up * moveSpeed // величина смещения по вертикали (езда)
            + Vector3.right * xInput * steeringSpeed) // величина руления с учетом ввода
            * Time.deltaTime; // привязка скоростей к реальному времени в секунду

        var camPosition = cam.transform.position; // вытаскиваем позицию из камеры
        camPosition.y = transform.position.y; // поправляем ей Y
        cam.transform.position = camPosition; // выставляем измененный вектор обратно камере
    }
}
