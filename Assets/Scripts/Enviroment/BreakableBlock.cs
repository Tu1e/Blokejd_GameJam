using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBlock : Traps
{
    [SerializeField] Animation animation;
    [SerializeField] TrapActions tapAction;
    [SerializeField] bool isBroken;
    private void OnTriggerEnter(Collider other) {

        if(other.gameObject.CompareTag("Player") && isBroken) {
            Destroy(gameObject, animation.clip.length);
            PlayAnimation(animation);
            ActivateTrap(tapAction);
        }

        if(!isBroken)
            isBroken = true;
        
    }

    private void OnDrawGizmos() 
    {
        // Try getting the MeshFilter component
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        if (meshFilter == null || meshFilter.sharedMesh == null) return;

        Gizmos.color = Color.green;
        Gizmos.matrix = transform.localToWorldMatrix; // Apply object's transformation
        Gizmos.DrawWireMesh(meshFilter.sharedMesh);  // Draw the wireframe mesh
    }

}
