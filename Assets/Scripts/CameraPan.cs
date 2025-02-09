using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour
{

    [SerializeField] private AnimationCurve curve;
    [SerializeField] public Vector3 StartPos;
    [SerializeField] public Vector3 EndPos;
    [SerializeField] private float speed;

    private float current = 0, target = 1;

    // Start is called before the first frame update
    void Start()
    {
        EndPos = StartPos = transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
        if(StartPos != EndPos){
            current = Mathf.MoveTowards(current, target, speed * Time.deltaTime);

            transform.position = Vector3.Lerp(StartPos, EndPos, curve.Evaluate(current));
        }                
    }
}
