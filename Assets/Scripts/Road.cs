using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    static GameManager manager;
    static Vector3 startPos;

    public static void SetManager(GameManager manager)
    {
        Road.manager = manager;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name != "road (2)") return;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (manager == null) return;
        var distToCamera = Camera.main.transform.position.y - transform.position.y;
        if (distToCamera <= manager.roadResetDisY) return;
        OvertakeCamera();
    }


    private void OvertakeCamera()
    {
        transform.position += startPos + Vector3.up * manager.roadResetDisY;
        SpawnObjects();
    }

    private void SpawnObjects()
    {
        int total = Random.Range(0, manager.lines + 1); // сколько всего препятствий нужно
        int needed = total; // сколько еще осталось
        for (int i = 0; i < manager.lines; i++) // обходим полосы движения от обочины до обочины
        {
            if (needed == 0) break; // если препятствий (больше) не нужно - прерываем обход
            else if (!TrySpawnAtLine(i, needed)) // если на этой полосе не выпало ...
                continue; // ...переходим к следующей
            needed--; // препятствие выпало - уменьшаем счетчик
        }
    }

    private bool TrySpawnAtLine(int lineInd, int needed)
    {
        var chance = needed / (float)(manager.lines - lineInd); // шанс выпадения объекта на этой полосе
        if (chance < 1 && Random.Range(0, 1f) > chance) // шанс должен быть меньше 1 и рандом его переходит
            return false; // оказалось так - препятствия не получили

        var x = manager.linesCentersX[lineInd]; // узнаем координаты середины этой полосы (всегда одни)
        CreateObstacle(x, manager.GetObstacle()); // просим непосредственно создать объект там
        return true; // объект создан - об этом обязаны сообщить
    }

    private void CreateObstacle(float x, GameObject prefab)
    {

        var obstPosition = new Vector3(x, transform.position.y); // задали позицию для препятствия
        Instantiate(prefab, obstPosition, Quaternion.identity); // создали его там (позиция, угол поворота)
    }
}


