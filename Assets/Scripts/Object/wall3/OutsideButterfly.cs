using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OutsideButterfly : Butterfly
{
    public override void Awake()
    {
        
    }

    public override void Start()
    {
        myTransform = new Vector3(Random.Range(-8f, 6f), Random.Range(-4.5f, 4.5f), 0f);
    }

    
}
