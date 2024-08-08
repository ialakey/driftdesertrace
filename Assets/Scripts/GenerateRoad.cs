using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRoad : MonoBehaviour
{
    public GameObject roadPrefab; // ������ �������� ������
    public Transform player; // ������ �� ������ ������ ��� ������
    public int roadLength = 10; // ����� ������ �������� ������
    public int initialRoadSegments = 5; // ��������� ���������� ���������
    public float spawnDistance = 20.0f; // ����������, �� ������� ������������ ����� ��������

    private List<GameObject> roadSegments = new List<GameObject>();
    private Vector3 nextSpawnPosition;

    void Start()
    {
        // ������������� ��������� ������� ��� ������� ��������
        nextSpawnPosition = Vector3.zero;

        // �������� ��������� ��������� ������
        for (int i = 0; i < initialRoadSegments; i++)
        {
            SpawnRoadSegment();
        }
    }

    void Update()
    {
        // ���������, ���� ����� ����������� � ����� ������� ������
        if (Vector3.Distance(player.position, nextSpawnPosition) < spawnDistance)
        {
            // ��������� ����� ������� ������
            SpawnRoadSegment();

            // ������� ������ ��������, ���� �� ������� �����
            if (roadSegments.Count > initialRoadSegments)
            {
                RemoveOldestSegment();
            }
        }
    }

    void SpawnRoadSegment()
    {
        // ������� ����� ������� ������
        GameObject newSegment = Instantiate(roadPrefab, nextSpawnPosition, Quaternion.identity);

        // ��������� ����� ������� � ������
        roadSegments.Add(newSegment);

        // ��������� ������� ��� ���������� ��������
        nextSpawnPosition += new Vector3(0, 0, roadLength);
    }

    void RemoveOldestSegment()
    {
        // ������� ����� ������ ������� ������
        Destroy(roadSegments[0]);
        roadSegments.RemoveAt(0);
    }
}
