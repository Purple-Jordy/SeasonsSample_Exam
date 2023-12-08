using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sinkWater : MonoBehaviour
{
    private sinkHandleLeft leftHandle;
    private sinkHandleRight rightHandle;
    private Animator animator;
    public static bool waterFlow = false; // 물 나옴 유무


    void Start()
    {
        leftHandle = GameObject.Find("sinkHandleLeft").GetComponent<sinkHandleLeft>();
        rightHandle = GameObject.Find("sinkHandleRight").GetComponent<sinkHandleRight>();
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        // 왼쪽이나 오른쪽 둘 중 하나가 On 상태면 물 나오는 애니메이션 true
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
