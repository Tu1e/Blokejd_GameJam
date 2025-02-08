using Unity.Jobs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

using static Unity.Mathematics.math;
using Unity.Burst;
using Unity.Collections;

[BurstCompile(FloatPrecision.Standard, FloatMode.Fast)]
struct InitializeVisualizationJob : IJobFor{
    [WriteOnly]
    public NativeArray<float3> positions, colors;

    public int rows, columns;

    public void Execute(int i){
        positions[i] = GetCellPosition(i);        
    }

    float3 GetCellPosition(int i){
        int r = i / columns;
        int c = i - r * columns;
        return float3(c - (columns - 1) * 0.5f, 0f, r - (rows - 1) * 0.5f);
    }
}