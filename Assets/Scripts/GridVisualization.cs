using System.Collections;
using Unity.Jobs;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using Unity.Mathematics;

using static Unity.Mathematics.math;
using Palmmedia.ReportGenerator.Core.Parser.Analysis;

public struct GridVisualization{
    static int positionsId = Shader.PropertyToID("_Positions"), 
    colorsId = Shader.PropertyToID("_Colors");

    ComputeBuffer positionsBuffer, colorsBuffer;

    NativeArray<float3> positions, colors;

    GridManager manager;

    Material material;

    Mesh mesh;

    public void Initialize(GridManager manager, Material material, Mesh mesh){
        this.manager = manager;
        this.material = material;
        this.mesh = mesh;

        int instanceCount = manager.CellCount;
        positions = new NativeArray<float3>(instanceCount, Allocator.Persistent);
        colors = new NativeArray<float3>(instanceCount, Allocator.Persistent);

        positionsBuffer = new ComputeBuffer(instanceCount, 3* 4);
        colorsBuffer = new ComputeBuffer(instanceCount, 3 * 4);
        material.SetBuffer(positionsId, positionsBuffer);
        material.SetBuffer(colorsId, colorsBuffer);
    }

    public void Dispose(){
        positions.Dispose();
        colors.Dispose();
        positionsBuffer.Dispose();
        colorsBuffer.Dispose();
    }

    public void Draw() => Graphics.DrawMeshInstancedProcedural(mesh, 0, material, new Bounds(Vector3.zero, Vector3.one), positionsBuffer.count);
    
}
