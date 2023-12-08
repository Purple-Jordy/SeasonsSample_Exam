using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingManager : MonoBehaviour
{
    public GameObject ceilingPhoto;

    private DisplayImage Display;


    void Start()
    {
        Display = GameObject.Find("displayImage").GetComponent<DisplayImage>();
    }


    void Update()
    {
        // 천장 상태일 때만 오브젝트 켜주기 
        if (Display.CurrentState == DisplayImage.State.ceiling)
        {
            ceilingPhoto.SetActive(true);
        }
        else
        {
            ceilingPhoto.SetActive(false);
        }
    }
}
