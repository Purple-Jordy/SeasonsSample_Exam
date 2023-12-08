using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Phone : MonoBehaviour, IInteractable
{
    //phone 애니메이션
    private Animator animator;

    // situation(말풍선) 애니메이션
    private GameObject situationUI;
    private TextMeshProUGUI situationText;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    private void Start()
    {
        // 말풍선UI들 가져오기
        situationUI = GameObject.Find("situationUI");
        situationText = situationUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }


    private void OnEnable()
    {
        animator.Rebind();
    }


    // 클릭 이벤트
    public void interact(DisplayImage currentDisplay)
    {
        //클릭 했을 때 폰을 안 들고 있으면 애니메이션들 재생
        if (animator.GetBool("PutOnPhone") == false)
        {
            //폰 애니메이션
            animator.SetBool("PutOnPhone", true);

            //말풍선 애니메이션
            situationUI.GetComponent<Animator>().Play("ShowItemNameAnim", -1, 0f);
            situationText.text = "너가 만지는 모든 것들은 변해.";

        }
        else if (animator.GetBool("PutOnPhone") == true) 
        {
            //폰을 들고 있으면 폰 내려놓는 애니메이션 재생
            animator.SetBool("PutOnPhone", false);
        }

    }
}
