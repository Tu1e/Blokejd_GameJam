using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTrap : Traps
{
    [SerializeField] Animation animation;
    [SerializeField] TrapActions tapAction;
    private void OnTriggerEnter(Collider other) {

        if(other.gameObject.CompareTag("Player")) {
            //PlayAnimation(animation);
            ActivateTrap(tapAction);
        }
    
        
    }

    private void OnDrawGizmos() 
    {
        // Try getting the MeshFilter component
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        if (meshFilter == null || meshFilter.sharedMesh == null) return;

        Gizmos.color = Color.red;
        Gizmos.matrix = transform.localToWorldMatrix; // Apply object's transformation
        Gizmos.DrawWireMesh(meshFilter.sharedMesh);  // Draw the wireframe mesh
    }

}
