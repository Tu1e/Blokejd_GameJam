using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "BoxScriptableObject", menuName = "Blokejd_GJ/BoxScriptableObject", order = 0)]
public class BoxScriptableObject : ScriptableObject {

    [SerializeField] CellState cellState;

    void Start(){
        switch (cellState){
            case CellState.Trap: 
            break;
        }    
    }
    
} 
