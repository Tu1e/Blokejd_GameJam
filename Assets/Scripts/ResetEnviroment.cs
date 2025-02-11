using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class ResetEnviroment : MonoBehaviour
{
    [SerializeField] GameObject block;
    [SerializeField] Vector3 blockPos;
    [SerializeField] Lift lift;

    void OnEnable(){
        PlayerManager.OnPlayerDied += Reset;
    }

    void OnDisable(){
        PlayerManager.OnPlayerDied -= Reset;
    }

    void Start(){
        blockPos = transform.position;
    }

    void Reset(){
        Instantiate(block, blockPos, new Quaternion(-90, 0, 0,0));
    }
}
