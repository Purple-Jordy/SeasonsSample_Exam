using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePointer : MonoBehaviour
{
    public static MousePointer instance;

    public GameObject circle; //클릭한 곳 알려주는 원
    private Animator animator; //원 생기는 애니메이션


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }


    private void Start()
    {
        animator = circle.GetComponent<Animator>();
    }


    void Update()
    {
        //화면 클릭시 클릭한 곳을 알려주는 원 생성 애니메이션 재생
        if (Input.GetMouseButtonDown(0))
        {
            circle.transform.position = Input.mousePosition; //원 생성 위치는 클릭 위치

            animator.Play("mouseAnim", -1, 0f); // 클릭시 바로 처음부터 재생되게
            
        }
    }

    
}
