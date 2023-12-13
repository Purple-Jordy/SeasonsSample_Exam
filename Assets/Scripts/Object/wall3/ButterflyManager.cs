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

        if (blackCube == null) //블랙큐브가 없어지면
        {
            
            butterflyCount = 0;

        }
        else // 블랙큐브가 있으면
        {
            if (EggCup.eggNum == 4)
            {
                butterflyCount = 1; //나비 생성
            }
            else if (EggCup.eggNum == 5)
            {
                butterflyCount = 4; //나비 생성
            }
            else if (EggCup.eggNum == 6)
            {
                butterflyCount = 30; //나비 총출동
            }
        }

       
    }


    
}
