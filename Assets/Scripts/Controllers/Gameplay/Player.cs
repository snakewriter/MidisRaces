using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager gameManager;
    public float steeringSpeed;
    public float accBrakeSpeed;
    public float moveSpeed;
    public float offcetToCamera = 3f;
    public bool gameover = false;

    Camera cam;
    float rotationRad;
    float dx, dy;
    Vector3 acceleration;



    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (gameover) return;

        var inputSteer = Input.GetAxis("Horizontal"); // Получаем руление
        var inputSpeed = Input.GetAxis("Vertical"); // Получаем ускорение/торможение

        transform.Rotate(0, 0, -inputSteer * steeringSpeed * Time.deltaTime); 
        // Поворачиваем с поправкой на текущий кадр и ввод
        CalcRotation(); // Вычисляем этот угол в радианах - вдруг превысили



        CalcMovement(inputSpeed);
        Move();

        var camPosition = cam.transform.position;
        camPosition.y = transform.position.y;
        cam.transform.position = camPosition;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        gameManager.HandleCollision(collision.gameObject);
    }



    void CalcRotation()
    {
        var rotation = transform.rotation.eulerAngles.z; // Перешли от кватернионов к градусам
        rotationRad = rotation / 360 * 2 * Mathf.PI; // Перевели градусы в радианы
        Debug.Log("rotation " + rotationRad);
    }

    void CalcMovement(float inputY)
    {
        dx = -Mathf.Sin(rotationRad); // Составляющая скорости по горизонтали
        dy = Mathf.Cos(rotationRad); // Составляющая скорости по вертикали

        /* В Юнити нулевой угол поворота повернут на 90, поэтому проекции инвертированы!!!
        (в математике проекция на OY - sin, OX - cos)
        Тригонометрические функции работают с радианами */

        acceleration = new Vector3(dx, dy) * // Нормализованное направление
            accBrakeSpeed * inputY; // С поправкой на величину ускорения/торможения и ввод
        offcetToCamera -= acceleration.y * Time.deltaTime; // Сдвиг камеры при ускорении/ торможении
    }

    void Move()
    {
        transform.position += 
            new Vector3(dx, dy) * moveSpeed * // Нормализованное направление с поправкой на скорость
            Time.deltaTime;
    }
}
