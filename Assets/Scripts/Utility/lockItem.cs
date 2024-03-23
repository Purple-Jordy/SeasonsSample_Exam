using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class lockItem : MonoBehaviour, IInteractable //�������̽�
{

    #region lockItem
    private Inventory inventory;
    private GameObject situationUI; // ��Ȳ �۾� UI 
    private Animator UIAnimator; // ��Ȳ �۾� UI �ִϸ��̼�
    private TextMeshProUGUI situationText; // ��Ȳ �۾� UI �ؽ�Ʈ

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


    //Ŭ�� �̺�Ʈ(Ŭ���� ��)
    public void interact(DisplayImage currentDisplay)
    {

        ItemUnlock(); // �ʿ��� �������� Ȯ���ؼ� ���/���� ǥ��

    }


    public virtual void ItemUnlock()
    {
        //�κ��丮�� ���� ���õ� ������ ��������Ʈ �̸��� ��Ͼ����� �̸��� ������ 
        if (inventory.currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem)
        {
            Debug.Log("unlock"); // �������
        }
        else
        {
            UIAnimator.Play("ShowItemNameAnim", -1, 0f); //��� �۾� �ִϸ��̼�

            situationText.text = lockText; //��� �۾� 

            //ȿ���� �÷���
            AudioManager.Instance.Play("locked");
        }
    }
}
