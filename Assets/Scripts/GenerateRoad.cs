using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRoad : MonoBehaviour
{
    public GameObject roadPrefab; // ������ �������� ������
    public Transform player; // ������ �� ������ ������ ��� ������
    public int roadLength = 210; // ����� ������ �������� ������
    public int roadSegmentsAhead = 3; // ���������� ��������� ������� ������
    public float spawnDistance = 10.0f; // ����������, �� ������� ������������ ����� ��������

    private List<GameObject> roadSegments = new List<GameObject>();
    private Vector3 nextSpawnPosition;

    void Start()
    {
        nextSpawnPosition = Vector3.zero;

        for (int i = 0; i < roadSegmentsAhead; i++)
        {
            SpawnRoadSegment();
        }
    }

    void Update()
    {
        if (Vector3.Distance(player.position, roadSegments[1].transform.position) < spawnDistance)
        {
            SpawnRoadSegment();

            RemoveOldestSegment();
        }
    }

    void SpawnRoadSegment()
    {
        GameObject newSegment = Instantiate(roadPrefab, nextSpawnPosition, Quaternion.identity);

        roadSegments.Add(newSegment);

        nextSpawnPosition += new Vector3(0, 0, roadLength);
    }

    void RemoveOldestSegment()
    {
        Destroy(roadSegments[0]);
        roadSegments.RemoveAt(0);
    }
}
