using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    [SerializeField] TrapActions tapAction;
    [SerializeField] KeyCards keyCards;

    [SerializeField] CameraPan camera;
    public static event Action OnLevelWon;
    bool isUsed = false;
    
    private void OnEnable() {
        Key.OnKeyCardCollected += HandleKeyCollected;
    }

    private void OnDisable(){
        Key.OnKeyCardCollected -= HandleKeyCollected;
    }

    private void OnTriggerEnter(Collider other) {

        if(other.gameObject.CompareTag("Player") && !isUsed) {
            if(keyCards.IsNot(KeyCards.KeycardA | KeyCards.KeycardB | KeyCards.KeycardC)){
                NextLvl();
                isUsed = true;
            }
        }
    }

    void NextLvl(){
        Debug.Log("Next level");
        OnLevelWon?.Invoke();

        camera.EndPos.y += 30f;
    }

    void HandleKeyCollected(KeyCards kCards){
        keyCards.Without(kCards);
    }
    
}


[System.Flags]
 public enum KeyCards{
        KeycardA = 1, KeycardB = 1 << 1, KeycardC = 1 << 2
}

public static class KeyCardsExtensionMethods{
    public static bool Is(this KeyCards s, KeyCards mask) => (s & mask) != 0;
    public static bool IsNot(this KeyCards s, KeyCards mask) => (s & mask) == 0;
    public static KeyCards With(this KeyCards s, KeyCards mask) => s | mask;
    public static KeyCards Without(this KeyCards s, KeyCards mask) => s & ~mask;
}
