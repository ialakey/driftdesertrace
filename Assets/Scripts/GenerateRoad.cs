using System.Collections.Generic;
using UnityEngine;

public class GenerateRoad : MonoBehaviour
{
    public GameObject roadPrefab; // Префаб сегмента дороги
    public Transform player; // Ссылка на объект игрока или камеры
    public int initialSegments = 3; // Количество сегментов, генерируемых при старте
    public int maxSegments = 6; // Максимальное количество сегментов на сцене

    private List<GameObject> roadSegments = new List<GameObject>();
    private float segmentLength; // Длина одного сегмента дороги

    void Start()
    {
        Renderer roadRenderer = roadPrefab.GetComponentInChildren<Renderer>();
        if (roadRenderer != null)
        {
            segmentLength = roadRenderer.bounds.size.z;
        }
        else
        {
            Debug.LogError("Не удалось найти компонент Renderer на префабе дороги. Убедитесь, что roadPrefab содержит Renderer или задайте длину сегмента вручную.");
            segmentLength = 210.0f;
        }

        for (int i = -initialSegments / 2; i < initialSegments / 2; i++)
        {
            Vector3 spawnPosition = new Vector3(0, 0, i * segmentLength);
            SpawnRoadSegment(spawnPosition);
        }
    }

    void Update()
    {
        if (roadSegments.Count == 0)
            return;

        if (player.position.z > roadSegments[roadSegments.Count - 1].transform.position.z - segmentLength)
        {
            SpawnRoadSegment(roadSegments[roadSegments.Count - 1].transform.position + new Vector3(0, 0, segmentLength));
            RemoveOldestSegment(false);
        }

        if (player.position.z < roadSegments[0].transform.position.z + segmentLength)
        {
            SpawnRoadSegment(roadSegments[0].transform.position - new Vector3(0, 0, segmentLength));
            RemoveOldestSegment(true);
        }
    }

    void SpawnRoadSegment(Vector3 position)
    {
        GameObject newSegment = Instantiate(roadPrefab, position, Quaternion.identity);
        roadSegments.Add(newSegment);
    }

    void RemoveOldestSegment(bool fromFront)
    {
        if (fromFront && roadSegments.Count > 0)
        {
            Destroy(roadSegments[0]);
            roadSegments.RemoveAt(0);
        }
        else if (!fromFront && roadSegments.Count > 0)
        {
            Destroy(roadSegments[roadSegments.Count - 1]);
            roadSegments.RemoveAt(roadSegments.Count - 1);
        }
    }
}
