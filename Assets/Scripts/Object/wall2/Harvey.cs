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
        //������ ������ ���� ���� �ʾҴٸ� �Դ� �ִϸ��̼� ���
        if (Feeding.isFeed == true && eatFeed == false && egg != null)
        {
            animator.SetTrigger("Eat");
            //ȿ���� �÷���
            AudioManager.Instance.Play("eatFeed");
            eatFeed = true;
        }
        else if (Feeding.isFeed == true && eatFeed == true && egg != null)
        {
            // ������ �ְ� ������ �Ծ��ٸ�
            //���� �ִϸ��̼� ���
           
                if (!eggOnGround)
                {
                    StartCoroutine(eggOnTheGround());
                }
                
            


            //���� ���� ȹ������ ���� ���¿� �Ϻ� �������� �Ϻ� �ִϸ��̼� ���
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
            // ������ ���� ���¿��� �Ϻ� ������ �Ϻ� �ִϸ��̼� ���
            animator.SetTrigger("harvey");
            //ȿ���� �÷���
            AudioManager.Instance.Play("HarveyTouch");
        }

        // ������ ������ ����
        Instantiate(featherPrefab);
        
    }


    IEnumerator eggOnTheGround()
    {
        animator.SetTrigger("egg");
        //ȿ���� �÷���
        AudioManager.Instance.Play("eatFeed");
        // ��ġ ����
        wait = 1f;

        yield return new WaitForSeconds(1f);

        //ȿ���� �÷���
        AudioManager.Instance.Play("eggOnGround");

        egg.GetComponent<Animator>().enabled = true;

        if (egg == null) //���� �������� ���߿� ȹ��� �� ����
        {
            egg.GetComponent<Animator>().enabled = false;
            eggOnGround = true;
            AudioManager.Instance.Stop("eggOnGround");
        }

        yield return new WaitForSeconds(1f);

        //egg.GetComponent<Animator>().SetBool("OnGround", true);
        
        eggOnGround = true;
    }

    //wait(�ð�)�� ���� ��ġ ����
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
