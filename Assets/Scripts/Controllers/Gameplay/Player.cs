using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager gameManager;
    public float offcetToCamera;
    public float steeringSpeed;
    public float accBrakeSpeed;
    public float moveSpeed;

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
        var inputSteer = Input.GetAxis("Horizontal");
        var inputY = Input.GetAxis("Vertical");


        transform.Rotate(0, 0, -steeringSpeed * inputSteer * Time.deltaTime);
        // Поворот с поправкой на скорость руления, ввод и текущий кадр
        CalcRotation(); // Проверяем угол - вдруг превысили


        CalcMovement(inputY);
        Move();
    }



    void CalcRotation()
    {
        var rotation = transform.rotation.eulerAngles.z; // Получили угол поворота
        rotationRad = rotation / 360 * 2 * Mathf.PI; // Привели его к радианам
    }

    void CalcMovement(float inputY)
    {
        dx = -Mathf.Sin(rotationRad); // Составляющая скорости по горизонтали
        dy = Mathf.Cos(rotationRad); // Составляющая скорости по вертикали

        /* Тригоноиметрические функции в Юнити используют радианы
         * Проекция угла на OY - sin, OX - cos, но в Юнити наоборот,
           т.к. нулевой угол поворота направлен вверх!!! */

        acceleration = new Vector3(dx, dy) * // Единичный вектор-направление с поправкой 
            accBrakeSpeed * inputY * Time.deltaTime; // на скорость ускорения/торможения и ввод
        offcetToCamera -= acceleration.y; // Отставание/опережение камеры
    }

    void Move()
    {
        transform.position += new Vector3(dx, dy) * moveSpeed * Time.deltaTime +
            acceleration; // Движемся в направлении с учетом ускорения/торможения

        var camPosition = cam.transform.position; // Учитываем камере
        camPosition.y = transform.position.y + offcetToCamera; // отставание/торможение
        cam.transform.position = camPosition; // Задаём камере нужное смещение
    }
}
