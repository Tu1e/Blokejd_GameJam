using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    [SerializeField] Animation animation;
    [SerializeField] TrapActions tapAction;
    [SerializeField] KeyCards keyCards;

    [SerializeField] CameraPan camera;


    private void OnTriggerEnter(Collider other) {

        if(other.gameObject.CompareTag("Player")) {
            if(keyCards.IsNot(KeyCards.KeycardA | KeyCards.KeycardB | KeyCards.KeycardC)){
                NextLvl();
            }
        }
    }

    void NextLvl(){
        //Larp logic
        Debug.Log("Next level");
        camera.EndPos.y += 100f;
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
