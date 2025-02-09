using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionManager : MonoBehaviour
{
    [SerializeField] Animator animator;

    private void OnEnable() {
        PlayerManager.OnLvlFinished += StartTranition;
    }

    private void OnDisable() {
        PlayerManager.OnLvlFinished -= StartTranition;
    }

    void StartTranition(){
        animator.SetTrigger("FinishLevel");
    }
}
