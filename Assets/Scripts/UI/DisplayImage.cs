using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayImage : MonoBehaviour
{
    public enum State // ȭ���� ���¸� ���� state ������
    {
        normal, // �Ϲ� 
        zoom, // �� 
        ChangedView, // ��ȯ ȭ��
        ceiling // õ�� 
    };
    

    public State CurrentState { get; set; } // �ڵ� �Ӽ�, ���� ȭ�� ����


    // ��ü �Ӽ�, ���� ��
    private int previousWall;
    public int PreviousWall
    {
        get { return currentWall; } // ���� ���� ���� ��ȯ
        set { currentWall = value; } // ���� ���� ���� ������
    }

    // ��ü �Ӽ�, ���� �� 
    private int currentWall; 
    public int CurrentWall
    {
        get { return currentWall; } // ���� ���� ���� ��ȯ
        set 
        {
            // õ�忡�� �ǳ��� ȭ������ �Ѿ ��츦 ���
            if(value == 5) 
            {
                currentWall = 1;
            }
            else if (value == 6)
            {
                currentWall = 2;
            }
            else if(value == 0) // 1���� 0���� ȭ���� �ű� ���
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
        // ȭ�� �ʱ�ȭ
        previousWall = 0; 
        currentWall = 1; 
        CurrentState = State.normal;
    }


    private void Update()
    {
        // ���� ���� ��� ���� ���� ���� �ʴٸ�(���� �̵��ߴٸ�)
        if (currentWall != previousWall)
        {
            //�������� ȭ�� ���ҽ� �ε�(ȭ���� ��ȣ�� �´� �̹��� �ҷ�����)
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/wall" + currentWall.ToString());
        }

        // ȭ���� �ٲ�� ���� ���� ���� ���� �� �������ֱ�
        previousWall = currentWall;
        
    }
}

