using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTrap : Traps
{
    [SerializeField] Animation animation;
    [SerializeField] TrapActions tapAction;
    private void OnTriggerEnter(Collider other) {

        if(other.gameObject.CompareTag("Player")) {
            PlayAnimation(animation);
            ActivateTrap(tapAction);
        }
    
        
    }

}
