using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstance : MonoBehaviour
{
    //[SerializeField] Animation moveAnim;
    [SerializeField] AnimationClip dieAnim;
    [SerializeField] Animator anim;

    public Cell currentCell;

    public void HandlePlayerInstanceDeath(){
        Destroy(anim);
        //anim.Play(dieAnim);
        

    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Box")){
            currentCell = other.GetComponent<Cell>();
        }
    }
    
}
