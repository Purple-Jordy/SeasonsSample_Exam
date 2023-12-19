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
    float wait = 0f;

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

        ResetClick();
    }


    public void interact(DisplayImage currentDisplay)
    {
        //음식이 있지만 아직 먹지 않았다면 먹는 애니메이션 재생
        if (Feeding.isFeed == true && eatFeed == false && egg != null)
        {
            animator.SetTrigger("Eat");
            //효과음 플레이
            AudioManager.Instance.Play("eatFeed");
            eatFeed = true;
        }
        else if (Feeding.isFeed == true && eatFeed == true && egg != null)
        {
            // 음식이 있고 음식을 먹었다면
            //알의 애니메이션 재생
           
                if (!eggOnGround)
                {
                    StartCoroutine(eggOnTheGround());
                }
                
            


            //알을 아직 획득하지 않은 상태에 하비를 눌렀으면 하비 애니메이션 재생
            if (egg.GetComponent<CapsuleCollider2D>().enabled )
            {
                if (eggOnGround)
                {
                    animator.SetTrigger("harvey");
                    AudioManager.Instance.Play("HarveyTouch");
                }
                
            }
            
        }
        else
        {
            // 음식이 없는 상태에서 하비 누르면 하비 애니메이션 재생
            animator.SetTrigger("harvey");
            //효과음 플레이
            AudioManager.Instance.Play("HarveyTouch");
        }

        // 깃털은 무조건 생성
        Instantiate(featherPrefab);
        
    }


    IEnumerator eggOnTheGround()
    {
        animator.SetTrigger("egg");
        //효과음 플레이
        AudioManager.Instance.Play("eatFeed");
        // 터치 막기
        wait = 1f;

        yield return new WaitForSeconds(1f);

        //효과음 플레이
        AudioManager.Instance.Play("eggOnGround");

        egg.GetComponent<Animator>().enabled = true;

        if (egg == null) //알이 내려오는 도중에 획득될 수 있음
        {
            egg.GetComponent<Animator>().enabled = false;
            eggOnGround = true;
            AudioManager.Instance.Stop("eggOnGround");
        }

        yield return new WaitForSeconds(1f);

        //egg.GetComponent<Animator>().SetBool("OnGround", true);
        
        eggOnGround = true;
    }

    //wait(시간)에 따른 터치 막기
    void ResetClick()
    {
        

        wait -= Time.deltaTime;

        if (wait > 0f)
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
        else if(wait <= 0)
        {
            this.GetComponent<BoxCollider2D>().enabled = true;
            wait = 0f;
        }

    }

}
