using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReduceMoves : Traps
{
    [SerializeField] Animation animation;
    [SerializeField] TrapActions tapAction;
    public static event Action ReduceMove;
    [SerializeField] int reduceAmount;
    private void OnTriggerEnter(Collider other) {

        if(other.gameObject.CompareTag("Player")) {
            Destroy(gameObject, animation.clip.length);
            PlayAnimation(animation);
            ReduceMNumber();
        }

        
    }

    void ReduceMNumber(){
        ReduceMove?.Invoke();
    }

    private void OnDrawGizmos() 
    {
        // Try getting the MeshFilter component
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        if (meshFilter == null || meshFilter.sharedMesh == null) return;

        Gizmos.color = Color.cyan;
        Gizmos.matrix = transform.localToWorldMatrix; // Apply object's transformation
        Gizmos.DrawWireMesh(meshFilter.sharedMesh);  // Draw the wireframe mesh
    }
}
