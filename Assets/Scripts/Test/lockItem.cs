using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class lockItem : MonoBehaviour, IInteractable
{

    #region lockItem
    private Inventory inventory;
    private GameObject situationUI;
    private Animator UIAnimator;
    private TextMeshProUGUI situationText;

    public string UnlockItem; //������� ������(�� �������� �־�� �������)

    //������ ���� �� ������ �۾�
    [SerializeField]
    private string lockText = "���";
    #endregion

    public void Start()
    {
        inventory = Inventory.Instance;
        situationUI = GameObject.Find("situationUI");
        UIAnimator = situationUI.GetComponent<Animator>();
        situationText = situationUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }


    //Ŭ�� �̺�Ʈ
    public void interact(DisplayImage currentDisplay)
    {

        ItemUnlock();

    }


    public virtual void ItemUnlock()
    {
        //�κ��丮�� ���� ���õ� ������ ��������Ʈ �̸��� ��Ͼ����� �̸��� ������ 
        if (inventory.currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem)
        {
            Debug.Log("unlock"); // �������
            //inven.currentSelectedSlot.GetComponent<Slot>().ClearSlot(); //���� ����
        }
        else
        {
            UIAnimator.Play("ShowItemNameAnim", -1, 0f);
            situationText.text = lockText;
            //ȿ���� �÷���
            AudioManager.Instance.Play("locked");
        }
    }
}
