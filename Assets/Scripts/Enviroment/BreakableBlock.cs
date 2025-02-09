using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class BreakableBlock : Traps
{
    [SerializeField] Animator animator;
    [SerializeField] TrapActions tapAction;
    [SerializeField] bool isBroken;
    [SerializeField] CellState state;

    void Start(){
        Debug.Log("Evo me", this);
    }
    private void OnTriggerEnter(Collider other) {

        if(other.gameObject.CompareTag("Player") && isBroken) {
            //Destroy(gameObject, animation.clip.length);
            //PlayAnimation(animation);
            
            ActivateTrap(tapAction);
        }
            
        
    }
    private void OnTriggerExit(Collider other) {

        if(other.gameObject.CompareTag("Player"))
        {
            if(!isBroken){
                animator.SetTrigger("SteppedOver");
                isBroken = true;
                state = 0;
            }
        }

        
            
        
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
