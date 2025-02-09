using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Traps : MonoBehaviour
{
    public static event Action KillPlayer;
    public static event Action SendSInfo;
    public void PlayAnimation(Animation anim){
        anim?.Play();
    } 

    public void ActivateTrap(TrapActions tActions){
        if(tActions == TrapActions.Kill)
            KillPlayer?.Invoke();
    }

    public void SendSurroundingsInfo(){

        SendSInfo?.Invoke();
    }

}

public enum TrapActions{
    Kill,
    ReduceMoves,
    DoNothing
}