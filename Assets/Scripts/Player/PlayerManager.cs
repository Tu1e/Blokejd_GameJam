using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] Rigidbody rb;
    [SerializeField] float speed;
    bool canWalk = true;

    Transform startingPos;
    GameObject player;
    private void OnEnable() {
        Traps.KillPlayer += HandlePlayerDeath;
        //OnLevelLoaded += HandleNewlevel;
    }

    private void OnDisable() {
        Traps.KillPlayer -= HandlePlayerDeath;
    }

    private void Start() {
        SpawnPlayer();
    }

    private void Update() {
        if(Input.GetAxisRaw("Horizontal") != 0){
            HorizontalMove();
        }
        else if(Input.GetAxisRaw("Vertical") != 0){
            VerticalMove();
        }
    }

    void SpawnPlayer(){
        player = Instantiate(playerPrefab, startingPos.position, Quaternion.identity);
        rb = player.GetComponent<Rigidbody>();

    }

    void HorizontalMove(){
        Debug.Log("Horizontal: " + Input.GetAxisRaw("Horizontal"));
        canWalk = false;
        //rb.velocity = 
    }

    void VerticalMove(){
        canWalk = false;
        Debug.Log("Vertical: " + Input.GetAxisRaw("Vertical"));
    }
    void HandlePlayerDeath(){
        canWalk = false;    
        player.GetComponent<PlayerInstance>().HandlePlayerInstanceDeath();
        SpawnPlayer();
    }
    IEnumerator Wait(float waitTime = 0.5f) {
        yield return new WaitForSeconds(waitTime);
        canWalk = true; 
    }

    void HandleNewlevel(){
        
        //tim
        SpawnPlayer();
        //startingPos = 
    }
}
