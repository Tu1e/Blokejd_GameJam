using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField, Min(1)]
    int rows = 10, columns = 10;

    [SerializeField]
    float cellSize = 1f; // Veličina ćelije

    [SerializeField]
    Material material;

    [SerializeField]
    Mesh mesh;

    GridManager manager;

    void OnEnable()
    {
        manager.Initialize(rows, columns);
    }

    void OnDisable()
    {
        manager.Dispose();
    }

    void Update()
    {
        if (manager.Rows != rows || manager.Columns != columns)
        {
            OnDisable();
            OnEnable();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Vector3 startPosition = transform.position; // Početna tačka grida

        // Iscrtavanje vertikalnih linija
        for (int x = 0; x <= columns; x++)
        {
            Vector3 start = startPosition + new Vector3(x * cellSize, 0, 0);
            Vector3 end = start + new Vector3(0, 0, rows * cellSize);
            Gizmos.DrawLine(start, end);
        }

        // Iscrtavanje horizontalnih linija
        for (int z = 0; z <= rows; z++)
        {
            Vector3 start = startPosition + new Vector3(0, 0, z * cellSize);
            Vector3 end = start + new Vector3(columns * cellSize, 0, 0);
            Gizmos.DrawLine(start, end);
        }
    }
}
