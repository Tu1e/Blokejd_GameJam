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

//        Destroy(gameObject, dieAnim.clip.length);
  //      moveAnim.Play();
    }
    public void PlayMoveAnimation(){
    //    moveAnim.Play();
    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Box")){
            Debug.Log("desilo se");
            currentCell = other.GetComponent<Cell>();
        }
    }
    
}
