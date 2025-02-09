using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using System;

public class PlayerManager : MonoBehaviour
{

    public enum PlayerMoves{
        Forward, Back, Left, Right, Nothing
    }

    [SerializeField] GameObject playerPrefab;
    [SerializeField] float speed;
    [SerializeField] int[] moves;
    int currentMovesLeft;
    bool canMove = true;

    [SerializeField] List<Transform> startingPos;
    Transform currentSpawnPos;

    Animator animator;  
    GameObject player;
    PlayerInstance playerInstance;

    PlayerMoves currentMove = PlayerMoves.Nothing;

    Vector3 desiredPosition;
    Vector3 currentPosition;
    
    private float currentLerp = 0, targetLerp = 1;

    public static event Action<int> OnPlayerMoved;
    private void OnEnable() {
        Traps.KillPlayer += HandlePlayerDeath;
        Lift.OnLevelWon += HandleNewlevel;
    }

    private void OnDisable() {
        Traps.KillPlayer -= HandlePlayerDeath;
        Lift.OnLevelWon -= HandleNewlevel;
    }

    private void Start() {
        SpawnPlayer();
    }

    private void Update() {
        if(canMove){
            PlayerInput();
            Move();
        }else{
            Lerping();
        }
    }
    int b = 0;
    void SpawnPlayer(){
        currentMovesLeft = moves[b];
        OnPlayerMoved?.Invoke(currentMovesLeft);
        currentSpawnPos = startingPos[b];
        player = Instantiate(playerPrefab, currentSpawnPos.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
        playerInstance = player.GetComponent<PlayerInstance>();
        animator = playerInstance.GetComponent<Animator>();
         Debug.Log("Player died");
        //rb = player.GetComponent<Rigidbody>();

    }

    void PlayerInput(){
        if(Input.GetKeyDown(KeyCode.W)){
            currentMove = PlayerMoves.Forward;
            canMove = false;
        }else if(Input.GetKeyDown(KeyCode.S)){
            currentMove = PlayerMoves.Back;
            canMove = false;
        }else if(Input.GetKeyDown(KeyCode.A)){
            currentMove = PlayerMoves.Left;
            canMove = false;
        }else if(Input.GetKeyDown(KeyCode.D)){
            currentMove = PlayerMoves.Right;
            canMove = false;
        }
    }
    void HandlePlayerDeath(){
        canMove = false;    
        player.GetComponent<PlayerInstance>().HandlePlayerInstanceDeath();
        SpawnPlayer();
       
        animator.SetBool("Dead", true);
    }

    void HandleNewlevel(){
        
        Destroy(player,0.2f);
        //tim
        b++;
        SpawnPlayer();
        //startingPos = 
    }

    void UseMove(){
        --currentMovesLeft;
        OnPlayerMoved?.Invoke(currentMovesLeft);
        if(currentMovesLeft < 0){
            HandlePlayerDeath();
            playerInstance.HandlePlayerInstanceDeath();
        }
    }
    void Lerping(){
        if(player.transform.localPosition != desiredPosition){
            currentLerp = Mathf.MoveTowards(currentLerp, targetLerp, speed * Time.deltaTime);
            player.transform.localPosition = Vector3.Lerp(currentPosition, desiredPosition, currentLerp);
        }else{
            canMove = true;
            currentLerp = 0;
            animator.SetBool("Idle", true);
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);
            animator.SetBool("Right", false);
            animator.SetBool("Left", false);
        }
    }

    void Move(){
        desiredPosition = currentPosition = player.transform.localPosition;
        if(currentMove == PlayerMoves.Forward && playerInstance.currentCell.cellState.Is(CellState.Forward)){
            desiredPosition.z += 2;
            player.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            animator.SetBool("Up", true);
            animator.SetBool("Idle", false);
            UseMove();
        }else if(currentMove == PlayerMoves.Back && playerInstance.currentCell.cellState.Is(CellState.Back)){
            desiredPosition.z -= 2;
            player.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            animator.SetBool("Down", true);
            animator.SetBool("Idle", false);
            UseMove();
        }else if(currentMove == PlayerMoves.Left && playerInstance.currentCell.cellState.Is(CellState.Left)){
            desiredPosition.x -= 2;
            animator.SetBool("Right", true);
            animator.SetBool("Idle", false);
            UseMove();
        }else if(currentMove == PlayerMoves.Right && playerInstance.currentCell.cellState.Is(CellState.Right)){
            desiredPosition.x += 2;
            animator.SetBool("Left", true);
            animator.SetBool("Idle", false);
            UseMove();
        }

        currentMove = PlayerMoves.Nothing;
    }
}