using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    static GameManager manager;
    static Vector3 startPosition;


    public static void SetManager(GameManager manager)
    {
        Road.manager = manager;
    }

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
            return; // Если точку обгона прошли
        ResetThis(); // ..обгоняем игрока
    }

    private void ResetThis()
    {
        transform.position += startPosition + Vector3.up * manager.resetDistanceY;
        SpawnObstacle();
    }

    private void SpawnObstacle()
    {
        int total = Random.Range(0, manager.lines + 1); // Сколько нужно
        int needed = total; // Сколько еще осталось создать
        for (int i = 0; i < manager.lines; i++)
        {
            if (needed == 0) break; // Препятствий больше не нужно
            else if (!SpawnObstAtLine(i, needed, total))
                continue; // Объект не сгенерировался ..
            needed--; // .. или сгенерировался - учитываем оставшиеся
        }
    }

    private bool SpawnObstAtLine(int lineInd, int needed, int total)
    {
        var limit = needed / (float)(manager.lines - lineInd); // Вероятность генерации
        if (limit < 1 && Random.Range(0, 1f) < limit) // Шанс попробовали...
            return false; // ...он не удался (на этой полосе нет препятствия)

        var x = manager.linesCentersX[lineInd]; // Это центр дорожной полосы
        CreateObstacle(x, manager.GetObstacle()); // На нём будет случайное препятствие
        return true; // ...и теперь шанс удался - об этом нужно сообщить
    }

    private void CreateObstacle(float positionX, GameObject prefab)
    {
        // позднее здесь будет задан разброс координат по высоте дороги

        // Расчитываем позицию будущего препятствия
        var obsPosition = new Vector3(positionX, transform.position.y);
        Instantiate(prefab, obsPosition, Quaternion.identity);
    }
}
