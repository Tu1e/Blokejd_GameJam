using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionManager : MonoBehaviour
{
    [SerializeField] Animator animator;

    private void OnEnable() {
        
    }

    void StartTranition(){
        animator.SetTrigger("FinishLevel");
    }
}
