using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePointer : MonoBehaviour
{
    public GameObject circle;
    private Animator animator;

    private void Start()
    {
        animator = circle.GetComponent<Animator>();
    }

    void Update()
    {
        //ȭ�� Ŭ�� üũ
        if (Input.GetMouseButtonDown(0))
        {
            circle.transform.position = Input.mousePosition;

            animator.Play("mouseAnim", -1, 0f);
            
        }
    }

    
}
