using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePointer : MonoBehaviour
{
    public static MousePointer instance;

    public GameObject circle;
    private Animator animator;


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
        //화면 클릭 체크
        if (Input.GetMouseButtonDown(0))
        {
            circle.transform.position = Input.mousePosition;

            animator.Play("mouseAnim", -1, 0f);
            
        }
    }

    
}
