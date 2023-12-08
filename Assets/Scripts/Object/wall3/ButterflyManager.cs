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

        if (blackCube == null)
        {
                butterflyCount = 0;
        }

       
    }


    
}
