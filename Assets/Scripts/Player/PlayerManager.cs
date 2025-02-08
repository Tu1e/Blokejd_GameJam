using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    GameObject player;
    private void OnEnable() {
        Traps.KillPlayer += HandlePlayerDeath;
    }

    private void OnDisable() {
        Traps.KillPlayer -= HandlePlayerDeath;
    }

    private void Start() {
        
    }

    private void Update() {
        if(Input.GetAxisRaw("Horizontal") != 0){

        }

        if(Input.GetAxisRaw("Vertical") != 0){

        }
    }

    void SpawnPlayer(){
        
    }

    void HorizontalMove(){
        
    }

    void VerticalMove(){
        
    }
    void HandlePlayerDeath(){

    }
}
