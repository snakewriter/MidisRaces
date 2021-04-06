using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public static GameManager manager;

    static Vector3 startPosition;


    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name != "road (2)") return;
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (manager == null) return; 
        // если менеджер еще не пришел - делать ничего нельзя

        var distToCamera = Camera.main.transform.position -
            transform.position;
        if (distToCamera.y < manager.resetDistanceY) return;
        OvertakePlayer();  // Обгоняем игрока по выходу за пределы камеры
    }

    private void OvertakePlayer()
    {
        transform.position += manager.resetDistanceY *
            Vector3.up + startPosition;
        manager.SpawnObstacles(transform.position.y);
    }
}
