using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager gameManager;
    public float steeringSpeed = 1.5f;
    public float gasBrakeSpeed = 1f;
    public float moveSpeed = 3f;
    public float offcetToCamera = 3f;

    Camera cam;
    Vector3 acceleration;
    float rotationRad;
    float dx, dy;


    
    void Start()
    {
        cam = Camera.main;
    }
        
    void Update()
    {
        var xInput = -Input.GetAxis("Horizontal"); // Положительное направление вращения
        // против часовой стрелки, в отличие от линейного ввода
        var yInput = Input.GetAxis("Vertical");

        transform.Rotate(0, 0, xInput * steeringSpeed);
        CalcRotation();

        CalcMovement(yInput);
        Move();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        gameManager.HandleCollision(collision.gameObject);
    }


    void CalcRotation()
    {
        var rotation = transform.rotation.eulerAngles.z;
        rotationRad = rotation / 360 * Mathf.PI * 2;
    }

    void CalcMovement(float inputY)
    {
        dx = -Mathf.Sin(rotationRad); // Нормализованная проекция на OX
        dy = Mathf.Cos(rotationRad); // то же, OY
        /* В Юнити тригонометрические функции используют аргумент в радианах
         * проекция на OX - cos, OY - sin, но в этой игре наоборот,
         * т.к. нулевой угол направлен вверх */
        acceleration = new Vector3(dx, dy) // направление ускорения с поправкой
            * gasBrakeSpeed * inputY * Time.deltaTime; // на величину и ввод
        offcetToCamera -= acceleration.y * Time.deltaTime;
    }

    void Move()
    {
        transform.position += new Vector3(dx, dy) // направление перемещения
            * moveSpeed * Time.deltaTime // скорость движения с поправкой на частоту кадров
            + acceleration; // Добавление ускорения (замедления)

        var camPosition = cam.transform.position; // вытаскиваем позицию из камеры
        camPosition.y = transform.position.y + offcetToCamera; // поправляем ей Y
        cam.transform.position = camPosition; // выставляем измененный вектор обратно камере
    }
}
