using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBlock : Traps
{
    [SerializeField] Animation animation;
    [SerializeField] TrapActions tapAction;
    private void OnTriggerEnter(Collider other) {

        if(other.gameObject.CompareTag("Player")) {
            DestroyBox();
            PlayAnimation(animation);
            ActivateTrap(tapAction);
        }
    
        
    }

    void DestroyBox(){
        Destroy(gameObject, animation.clip.length);
    }
}
