using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInstance : MonoBehaviour
{
    //[SerializeField] Animation moveAnim;
    [SerializeField] AnimationClip dieAnim;
    [SerializeField] Animator anim;

    public Cell currentCell;

    public void HandlePlayerInstanceDeath(){
        anim.SetBool("Dead", true);
        //Destroy(anim);

    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Box")){
            currentCell = other.GetComponent<Cell>();
        }
    }
    
}
