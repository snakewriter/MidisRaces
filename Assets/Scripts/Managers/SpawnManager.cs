using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager 
{
    public static ScriptsManager manager;
    public static PrefabStorage prefabStorage;

    float spawnCenterY;


    
    public void SpawnObjects(float spawnCenterY)
    {
        this.spawnCenterY = spawnCenterY;
        SpawnObstacles();
    }



    private void SpawnObstacles()
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
        var chance = needed / (float)(manager.lines - lineInd); // Вероятность генерации
        if (chance < 1 && Random.Range(0, 1f) > chance) // Шанс попробовали...
            return false; // ...он не удался (на этой полосе нет препятствия)

        var x = manager.linesCentersX[lineInd]; // Это центр дорожной полосы
        CreateObstacle(x, prefabStorage.GetRandomPrefab()); // На нём будет случайное препятствие
        return true; // ...и теперь шанс удался - об этом нужно сообщить
    }

    private void CreateObstacle(float positionX, GameObject prefab)
    {
        var heightRange = manager.roadHeight - 1; // интервал по высоте
        var positionY = spawnCenterY + heightRange *
            (0.5f - Random.Range(0, 1f)); // позиция по высоте = центр +/- половина

        // Расчитываем позицию будущего препятствия
        var obsPosition = new Vector3(positionX, positionY);
        Object.Instantiate(prefab, obsPosition, Quaternion.identity);
    }
}
