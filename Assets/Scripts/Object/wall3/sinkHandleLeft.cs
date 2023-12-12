using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sinkHandleLeft : MonoBehaviour, IInteractable
{
    
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public bool waterOn = false;

    private SaveAndLoad theSaveAndLoad;

    void Start()
    {
        animator = GameObject.Find("sink").GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        theSaveAndLoad = FindObjectOfType<SaveAndLoad>();
    }


    public void interact(DisplayImage currentDisplay)
    {
        // Ŭ�� �ִϸ��̼�
        animator.SetTrigger("waterOn");

        // ������ ��� ����
        StartCoroutine(sinkAnim());

    }


    IEnumerator sinkAnim()
    {
        //Ŭ�� �ִϸ��̼� ��� �� ������ �̹��� ����

        yield return new WaitForSeconds(0.3f);

        if (waterOn) //true/false ���¿� ���� ������ ��� �ٲ��ֱ�
        {
            this.spriteRenderer.sprite = Resources.Load<Sprite>("Sprites/sink4");
            waterOn = false;
        }
        else
        {
            this.spriteRenderer.sprite = Resources.Load<Sprite>("Sprites/sink6");
            waterOn = true;

            //���� Ʋ�� ����
            if (kitchenPot.potOnSink)
            {
                theSaveAndLoad.SaveData();
            }
        }
    }


}
