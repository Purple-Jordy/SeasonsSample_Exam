using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotCheck : MonoBehaviour
{
    public GameObject originPot;
    
    void Update()
    {
        if(originPot != null)
        {
            Destroy(originPot);
        }
    }
}
