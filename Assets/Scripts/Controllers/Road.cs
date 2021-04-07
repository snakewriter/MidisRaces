using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public static GameManager manager;

    static Vector3 startPosition;




    void Start()
    {
        if (gameObject.name != "road (2)") return; // Только для верхнего сегмента
        startPosition = transform.position; // ..сохраняем исходную позицию
    }

    // Update is called once per frame
    void Update()
    {
        if (manager == null) return; // Пока менеджера нет - не двигаться
        var distToCamera = Camera.main.transform.position.y -
            transform.position.y; // Расстояние до камеры

        if (distToCamera <= manager.resetDistanceY) 
            return; // Если точку обгона прошли ...
        OvertakeCamera(); // .. обгоняем игрока
    }



    private void OvertakeCamera()
    {
        transform.position += startPosition + Vector3.up * manager.resetDistanceY;
        manager.SpawnObstacles(transform.position.y);
    }
}
