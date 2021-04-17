using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager // здесь происходит правильный спаун
{
    public static ScriptsManager manager;
    public static PrefabStorage prefabStorage;

    float roadLineCenterY; // середина высоты дорожного сегмента
    int availableLines = manager.lines + 1;


    public void SpawnObjects(float roadLineCenterY)
    {
        this.roadLineCenterY = roadLineCenterY; // Сохраняем на время выполнения
        // чтобы не пробрасывать из метода в метод
        LoopThroughLines(); // обходим все дорожные полосы
    }

    private void LoopThroughLines()
    {
        int total = Random.Range(0, availableLines); // столько препятствий нужно на этом сегменте
        int needed = total; // столько препятствий еще осталось
        for (int i = 0; i < manager.lines; i++)
        {
            if (needed == 0) break; // ни одного препятствия больше не нужно (было)
            else if (!TrySpawnAtLine(i, needed, total)) // запрашиваем создание препятствия
                continue; // препятствие не выпало - переходим к следующей полосе
            needed--; // иначе уменьшаем количество препятствий которое еще нужно
        }
    }

    private bool TrySpawnAtLine(int lineInd, int needed, int total)
    {
        var chance = needed / (float)(manager.lines - lineInd); // шанс выпадения 
        if (chance < 1 && Random.Range(0, 1f) > chance) // получился шанс от 0 до 1 ...
            return false; // ...им не воспользовались

        var x = manager.roadLinesCentersX[lineInd]; // узнаём середину этой дорожной полосы 
        var prefab = prefabStorage.GetRandomPrefab(); // получаем префаб случайного препятствия
        CreateObj(x, prefab); // запрашиваем создание объекта на сцене
        return true; // сообщаем что создание объекта состоялось
    }

    private void CreateObj(float positionX, GameObject prefab)
    {
        var spawnHeightRange = manager.roadHeight - 1; // Задаем величину разброса по высоте дороги
        // середина высоты дороги +/- половина величины разброса
        var positionY = roadLineCenterY + spawnHeightRange * (0.5f - Random.Range(0, 1f));
        var objPosition = new Vector3(positionX, positionY); // конечная позиция препятствия
        Object.Instantiate(prefab, objPosition, Quaternion.identity); // препятствие появляется
    }
}
