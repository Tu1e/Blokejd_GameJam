using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI movesLeft;


    private void OnEnable() {
        PlayerManager.OnPlayerMoved += UpdateUI;
    }

    private void OnDisable(){
        PlayerManager.OnPlayerMoved -= UpdateUI;
    }

    void UpdateUI(int mLeft){
        if(mLeft == 0){
            movesLeft.color = Color.red;
            movesLeft.text = "No moves left!";
            return;
        }
        movesLeft.color = Color.white;
        movesLeft.text = "Moves left: " + mLeft;
    }
}
