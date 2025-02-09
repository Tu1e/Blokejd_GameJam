using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] KeyCards keyCard;

    public static event Action<KeyCards> OnKeyCardCollected;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")){
            OnKeyCardCollected?.Invoke(keyCard);
            Destroy(gameObject);
        }
    }
    
}
