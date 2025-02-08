using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBox : Traps
{
    [SerializeField] Animation animation;
    [SerializeField] TrapActions tapAction;
    [SerializeField] bool isOpen;

    void OnEnable(){
       // PlayerManager.OnPlayerMoved += SwitchState;
    }

    void OnDisable(){
        //PlayerManager.OnPlayerMoved -= SwitchState;
    }
    private void OnTriggerEnter(Collider other) {

        if(other.gameObject.CompareTag("Player") && isOpen) {
            Destroy(gameObject, animation.clip.length);
            PlayAnimation(animation);
            ActivateTrap(tapAction);
        }
    
        
    }

void SwitchState() => isOpen = !isOpen;

}
