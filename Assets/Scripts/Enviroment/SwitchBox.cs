using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class SwitchBox : Traps
{
    [SerializeField] Animator animator;
    [SerializeField] TrapActions tapAction;
    [SerializeField] bool isOpen;

    private bool startingPos;

    void OnEnable(){
        PlayerManager.OnPlayerMadeMove += SwitchState;
        PlayerManager.OnPlayerDied += Reset;
    }

    void OnDisable(){
        PlayerManager.OnPlayerMadeMove -= SwitchState;
        PlayerManager.OnPlayerDied -= Reset;
    }

    private void Start() {
        animator.SetBool("IsOpen",isOpen);
        startingPos = isOpen;
    }
        private void OnTriggerEnter(Collider other) {

        if(other.gameObject.CompareTag("Player") && isOpen) {
            ActivateTrap(tapAction);
        }
    

        
        
    }

    public void Reset(){
        if(startingPos != isOpen)
            SwitchState();
    }

void SwitchState(){
    isOpen = !isOpen;
    animator.SetBool("IsOpen",isOpen);
}

private void OnDrawGizmos() 
    {
        // Try getting the MeshFilter component
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        if (meshFilter == null || meshFilter.sharedMesh == null) return;

        Gizmos.color = Color.blue;
        Gizmos.matrix = transform.localToWorldMatrix; // Apply object's transformation
        Gizmos.DrawWireMesh(meshFilter.sharedMesh);  // Draw the wireframe mesh
    }

}
