using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingManager : MonoBehaviour
{
    public GameObject ceilingPhoto;

    private DisplayImage display;


    void Start()
    {
        display = FindObjectOfType<DisplayImage>();
    }


    void Update()
    {
        // 천장 상태일 때만 오브젝트 켜주기 
        if (display.CurrentState == DisplayImage.State.ceiling)
        {
            ceilingPhoto.SetActive(true);
        }
        else
        {
            ceilingPhoto.SetActive(false);
        }
    }
}
