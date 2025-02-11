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

    void OnEnable(){
        Lift.DisableEntities += OnLevelFinished;
    } 

    void OnDisable(){
         Lift.DisableEntities -= OnLevelFinished;
    }

    public void HandlePlayerInstanceDeath(){
        tag = "Corpse";
    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Box")){
            currentCell = other.GetComponent<Cell>();
        }
    }

    private void OnLevelFinished(){
        if(tag == "Corpse"){
            gameObject.SetActive(false);
        }
    }
    
}
