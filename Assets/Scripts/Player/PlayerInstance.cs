using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstance : MonoBehaviour
{
    //[SerializeField] Animation moveAnim;
    //[SerializeField] Animation dieAnim;
    //[SerializeField] Animator anim;

    public Cell currentCell;

    public void HandlePlayerInstanceDeath(){
        Destroy(this);

    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Box")){
            currentCell = other.GetComponent<Cell>();
        }
    }
    
}
