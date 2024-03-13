using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayImage : MonoBehaviour
{
    public enum State // 화면의 상태를 관리 state 열거형
    {
        normal, // 일반 
        zoom, // 줌 
        ChangedView, // 변환 화면
        ceiling // 천장 
    };
    

    public State CurrentState { get; set; } // 자동 속성, 현재 화면 상태


    // 전체 속성, 이전 벽
    private int previousWall;
    public int PreviousWall
    {
        get { return currentWall; } // 현재 벽의 값을 반환
        set { currentWall = value; } // 현재 벽의 값을 가져옴
    }

    // 전체 속성, 현재 벽 
    private int currentWall; 
    public int CurrentWall
    {
        get { return currentWall; } // 현재 벽의 값을 반환
        set 
        {
            // 천장에서 건너편 화면으로 넘어갈 경우를 대비
            if(value == 5) 
            {
                currentWall = 1;
            }
            else if (value == 6)
            {
                currentWall = 2;
            }
            else if(value == 0) // 1에서 0으로 화면을 옮길 경우
            {
                currentWall = 4;
            }
            else
            {
                currentWall = value;
            }
        }
    }


    private void Start()
    {
        // 화면 초기화
        previousWall = 0; 
        currentWall = 1; 
        CurrentState = State.normal;
    }


    private void Update()
    {
        // 만약 현재 방과 이전 방이 같지 않다면(방을 이동했다면)
        if (currentWall != previousWall)
        {
            //동적으로 화면 리소스 로드(화면의 번호에 맞는 이미지 불러오기)
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/wall" + currentWall.ToString());
        }

        // 화면이 바뀌고 나서 이전 벽에 현재 벽 저장해주기
        previousWall = currentWall;
        
    }
}

