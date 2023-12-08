using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayImage : MonoBehaviour
{
    public enum State
    {
        normal, zoom, ChangedView, ceiling
    };
    
    public State CurrentState {  get; set; }


    private int previousWall;
    public int PreviousWall
    {
        get { return currentWall; }
        set { currentWall = value; }
    }

    private int currentWall;
    public int CurrentWall
    {
        get { return currentWall; }
        set 
        {
            if(value == 5)
            {
                currentWall = 1;
            }
            else if (value == 6)
            {
                currentWall = 2;
            }
            else if(value == 0)
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
        // 방 초기화
        previousWall = 0; 
        currentWall = 1; 
        CurrentState = State.normal;
    }


    private void Update()
    {
        // 만약 현재 방과 이전 방이 같지 않다면
        if (currentWall != previousWall)
        {
            //동적으로 리소스 로드
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/wall" + currentWall.ToString());
        }

        //
        previousWall = currentWall;
    }
}

