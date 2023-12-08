using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sinkWater : MonoBehaviour
{
    private sinkHandleLeft leftHandle;
    private sinkHandleRight rightHandle;
    private Animator animator;
    public static bool waterFlow = false; // �� ���� ����


    void Start()
    {
        leftHandle = GameObject.Find("sinkHandleLeft").GetComponent<sinkHandleLeft>();
        rightHandle = GameObject.Find("sinkHandleRight").GetComponent<sinkHandleRight>();
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        // �����̳� ������ �� �� �ϳ��� On ���¸� �� ������ �ִϸ��̼� true
        if(leftHandle.waterOn == true || rightHandle.waterOn == true)
        {
            animator.SetBool("waterOn", true);
            waterFlow = true;
        }
        else
        {
            animator.SetBool("waterOn", false);
            waterFlow = false;
        }
    }
}
