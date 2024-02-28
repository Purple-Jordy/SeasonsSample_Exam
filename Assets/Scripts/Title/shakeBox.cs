using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shakeBox : MonoBehaviour
{
    // 위아래 흔들림 속도
    [SerializeField]
    private float verticalBobFrequency = 1f;

    // 위아래 흔들림 진폭량
    [SerializeField]
    private float bobingAmount = 1f;

    // 처음 위치 
    private Vector3 startPosition;


    private void Start()
    {
        // 초기화
        startPosition = transform.position;
    }


    private void Update()
    {
        // 위 아래 흔들림
        float bobingAnimationPhase = Mathf.Sin(verticalBobFrequency * Time.time) * bobingAmount;
        transform.position = startPosition + Vector3.up * bobingAnimationPhase;
    }


    //비활성화될 때마다 호출
    private void OnDisable()
    {
        transform.position = startPosition;
    }

    
}
