using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    public GameObject slotBackground;


    private void OnEnable()
    {
        slotBackground.GetComponent<Animator>().SetTrigger("backButtonOn");
        Debug.Log("button On");
    }

    
}
