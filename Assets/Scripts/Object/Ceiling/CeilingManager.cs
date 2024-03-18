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
        // õ�� ������ ���� ������Ʈ ���ֱ� 
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
