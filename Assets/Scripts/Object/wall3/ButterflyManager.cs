using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyManager : ButterflyController
{

    private DisplayImage displayImage;

    
    public GameObject blackCube;



    public override void Start()
    {
        base.Start();

        displayImage = GameObject.Find("displayImage").GetComponent<DisplayImage>();
        
    }


    public override void Update()
    {
        base.Update();

        if (blackCube == null) //��ť�갡 ��������
        {
            
            butterflyCount = 0;

        }
        else // ��ť�갡 ������
        {
            if (EggCup.eggNum == 4)
            {
                butterflyCount = 1; //���� ����
            }
            else if (EggCup.eggNum == 5)
            {
                butterflyCount = 4; //���� ����
            }
            else if (EggCup.eggNum == 6)
            {
                butterflyCount = 30; //���� ���⵿
            }
        }

       
    }


    
}
