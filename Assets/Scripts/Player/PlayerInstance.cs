using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstance : MonoBehaviour
{
    [SerializeField] Animation moveAnim;
    [SerializeField] Animation dieAnim;
    [SerializeField] Animator anim;

    public void HandlePlayerInstanceDeath(){

        Destroy(this, dieAnim.clip.length);
        moveAnim.Play();
    }
    public void PlayMoveAnimation(){
        moveAnim.Play();
    }
}
