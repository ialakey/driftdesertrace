using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRoad : MonoBehaviour
{
    public GameObject roadPrefab; // Префаб сегмента дороги
    public Transform player; // Ссылка на объект игрока или камеры
    public int roadLength = 10; // Длина одного сегмента дороги
    public int initialRoadSegments = 5; // Начальное количество сегментов
    public float spawnDistance = 20.0f; // Расстояние, на котором генерируются новые сегменты

    private List<GameObject> roadSegments = new List<GameObject>();
    private Vector3 nextSpawnPosition;

    void Start()
    {
        // Инициализация начальной позиции для первого сегмента
        nextSpawnPosition = Vector3.zero;

        // Создание начальных сегментов дороги
        for (int i = 0; i < initialRoadSegments; i++)
        {
            SpawnRoadSegment();
        }
    }

    void Update()
    {
        // Проверяем, если игрок приблизился к концу текущей дороги
        if (Vector3.Distance(player.position, nextSpawnPosition) < spawnDistance)
        {
            // Добавляем новый сегмент дороги
            SpawnRoadSegment();

            // Удаляем старые сегменты, если их слишком много
            if (roadSegments.Count > initialRoadSegments)
            {
                RemoveOldestSegment();
            }
        }
    }

    void SpawnRoadSegment()
    {
        // Создаем новый сегмент дороги
        GameObject newSegment = Instantiate(roadPrefab, nextSpawnPosition, Quaternion.identity);

        // Добавляем новый сегмент в список
        roadSegments.Add(newSegment);

        // Обновляем позицию для следующего сегмента
        nextSpawnPosition += new Vector3(0, 0, roadLength);
    }

    void RemoveOldestSegment()
    {
        // Удаляем самый старый сегмент дороги
        Destroy(roadSegments[0]);
        roadSegments.RemoveAt(0);
    }
}
