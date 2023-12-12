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
        //������ ������ ���� ���� �ʾҴٸ� �Դ� �ִϸ��̼� ���
        if (Feeding.isFeed == true && eatFeed == false && egg != null)
        {
            animator.SetTrigger("Eat");
            eatFeed = true;
        }
        else if (Feeding.isFeed == true && eatFeed == true && egg != null)
        {
            // ������ �ְ� ������ �Ծ��ٸ�
            //���� �ִϸ��̼� ���
            if (egg != null)
            {
                StartCoroutine(eggOnTheGround());
            }
           
            
            
            //���� ���� ȹ������ ���� ���¿� �Ϻ� �������� �Ϻ� �ִϸ��̼� ���
            if(egg.GetComponent<CapsuleCollider2D>().enabled )
            {
                animator.SetTrigger("harvey");
            }
            
        }
        else
        {
            // ������ ���� ���¿��� �Ϻ� ������ �Ϻ� �ִϸ��̼� ���
            animator.SetTrigger("harvey");
        }

        // ������ ������ ����
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
