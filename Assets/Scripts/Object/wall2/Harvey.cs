using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Harvey : MonoBehaviour, IInteractable
{

    public GameObject featherPrefab;
    public Feeding feed;
    private GameObject egg;
    private DisplayImage displayImage;

    private Animator animator;
    private bool eatFeed = false;
    public static bool eggOnGround = false;


    private void Start()
    {
        animator = GetComponent<Animator>();
        displayImage = GameObject.Find("displayImage").GetComponent<DisplayImage>();
             
        egg = GameObject.Find("egg");
        
    }


    private void Update()
    {
        if (eggOnGround)
        {
            //
            if(egg != null)
            {
                egg.GetComponent<Animator>().SetBool("OnGround", true);
                egg.GetComponent<Animator>().enabled = true;
            }
            
        }    
    }


    public void interact(DisplayImage currentDisplay)
    {
        //음식이 있지만 아직 먹지 않았다면 먹는 애니메이션 재생
        if (Feeding.isFeed == true && eatFeed == false && egg != null)
        {
            animator.SetTrigger("Eat");
            eatFeed = true;
        }
        else if (Feeding.isFeed == true && eatFeed == true && egg != null)
        {
            // 음식이 있고 음식을 먹었다면
            //알의 애니메이션 재생
            if (egg != null)
            {
                StartCoroutine(eggOnTheGround());
            }
           
            
            
            //알을 아직 획득하지 않은 상태에 하비를 눌렀으면 하비 애니메이션 재생
            if(egg.GetComponent<CapsuleCollider2D>().enabled )
            {
                animator.SetTrigger("harvey");
            }
            
        }
        else
        {
            // 음식이 없는 상태에서 하비 누르면 하비 애니메이션 재생
            animator.SetTrigger("harvey");
        }

        // 깃털은 무조건 생성
        Instantiate(featherPrefab);
        
    }


    IEnumerator eggOnTheGround()
    {
        egg.GetComponent<Animator>().enabled = true;

        yield return new WaitForSeconds(1f);

        //egg.GetComponent<Animator>().SetBool("OnGround", true);

        egg.GetComponent<Animator>().enabled = false;
        eggOnGround = true;

    }



}
