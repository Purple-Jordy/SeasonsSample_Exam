using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feed : ItemPickUp
{
    private void Update()
    {
        if (Feeding.isFeed)
        {
            Destroy(gameObject);
        }
    }

    
}
