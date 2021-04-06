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
        var distToCamera = Camera.main.transform.position -
            transform.position;
        if (distToCamera.y < manager.resetDistanceY) return;
        OvertakePlayer();  // Обгоняем игрока
    }

    private void OvertakePlayer()
    {
        transform.position += manager.resetDistanceY *
            Vector3.up + startPosition;
    }
}
