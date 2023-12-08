using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firewood : ItemPickUp
{
    private void Update()
    {
        if (fireplace.woodHere)
        {
            Destroy(gameObject);
        }
    }
}
