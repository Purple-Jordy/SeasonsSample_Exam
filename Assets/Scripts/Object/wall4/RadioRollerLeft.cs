using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RadioRollerLeft : MonoBehaviour, IInteractable
{

    #region lockItem
    private Inventory inventory;
    private GameObject situationUI;
    private Animator UIAnimator;
    private TextMeshProUGUI situationText;

    //������ ���� �� ������ �۾�
    [SerializeField]
    private string lockText = "���� �Ҿ���";
    #endregion


    private RadioFrequency radioPart3;
    private Animator animator;


    void Start()
    {
        inventory = Inventory.Instance;
        situationUI = GameObject.Find("situationUI");
        UIAnimator = situationUI.GetComponent<Animator>();
        situationText = situationUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        radioPart3 = GameObject.Find("radioPart3").GetComponent<RadioFrequency>();
        animator = GetComponent<Animator>();
    }


    public void interact(DisplayImage currentDisplay)
    {
        Said();

        if (radioPart3.pointsIndex != 0)
        {
            radioPart3.pointsIndex -= 1;
            animator.SetTrigger("Click");
        }
        else
        {
            radioPart3.pointsIndex = 0;

        } 
        
    }


    void Said()
    {
        UIAnimator.Play("ShowItemNameAnim", -1, 0f);
        situationText.text = lockText;
    }


}
