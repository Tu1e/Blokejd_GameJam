using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public enum PlayerMoves{
        Forward, Back, Left, Right, Nothing
    }

    [SerializeField] GameObject playerPrefab;
    [SerializeField] float speed;
    bool canWalk = true;

    [SerializeField] Transform startingPos;
    GameObject player;
    PlayerInstance playerInstance;

    PlayerMoves currentMove = PlayerMoves.Nothing;

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
        PlayerInput();
        Move();
        //Debug.Log(playerInstance.currentCell.cellState);
    }

    void SpawnPlayer(){
        player = Instantiate(playerPrefab, new Vector3(0f, 1f, 0f), Quaternion.identity);
        playerInstance = player.GetComponent<PlayerInstance>();
        //rb = player.GetComponent<Rigidbody>();

    }

    void PlayerInput(){
        if(Input.GetKeyDown(KeyCode.W)){
            currentMove = PlayerMoves.Forward;
        }else if(Input.GetKeyDown(KeyCode.S)){
            currentMove = PlayerMoves.Back;
        }else if(Input.GetKeyDown(KeyCode.A)){
            currentMove = PlayerMoves.Left;
        }else if(Input.GetKeyDown(KeyCode.D)){
            currentMove = PlayerMoves.Right;
        }
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



    void Move(){
        Vector3 p = player.transform.localPosition;
        if(currentMove == PlayerMoves.Forward && playerInstance.currentCell.cellState.Is(CellState.Forward)){
            p.z += 2;
        }else if(currentMove == PlayerMoves.Back && playerInstance.currentCell.cellState.Is(CellState.Back)){
            p.z -= 2;
        }else if(currentMove == PlayerMoves.Left && playerInstance.currentCell.cellState.Is(CellState.Left)){
            p.x -= 2;
        }else if(currentMove == PlayerMoves.Right && playerInstance.currentCell.cellState.Is(CellState.Right)){
            p.x += 2;
        }

        currentMove = PlayerMoves.Nothing;
        player.transform.localPosition = p;
    }
}
