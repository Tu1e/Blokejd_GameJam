using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField, Min(1)]
    int rows = 10, columns = 10;

    [SerializeField]
    Material material;

    [SerializeField]
    Mesh mesh;

    GridManager manager;
    GridVisualization visualization;

    void OnEnable(){
        manager.Initialize(rows, columns);
        visualization.Initialize(manager, material, mesh);
    }

    void OnDisable(){
        manager.Dispose();
        visualization.Dispose();
    }

    void Update(){
        if(manager.Rows != rows || manager.Columns != columns){
            OnDisable();
            OnEnable();
        }
        visualization.Draw();
    }
}
