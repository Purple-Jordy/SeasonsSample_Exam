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
        // �� �ʱ�ȭ
        previousWall = 0; 
        currentWall = 1; 
        CurrentState = State.normal;
    }


    private void Update()
    {
        // ���� ���� ��� ���� ���� ���� �ʴٸ�
        if (currentWall != previousWall)
        {
            //�������� ���ҽ� �ε�
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/wall" + currentWall.ToString());
        }

        //
        previousWall = currentWall;
    }
}

