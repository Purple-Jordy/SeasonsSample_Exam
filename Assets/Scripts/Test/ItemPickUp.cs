using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour, IInteractable //�������̽� ���
{
    public Item item; //�ּ� ������

    Inventory Inventory;
    private SaveAndLoad theSaveAndLoad;


    public virtual void Start()
    {
        Inventory = Inventory.Instance;
        Inventory.Instance.CheckItem(this.gameObject); // ���� ���� Ȯ��
        theSaveAndLoad = FindObjectOfType<SaveAndLoad>();
    }


    // ������ ȹ��
    public virtual void CanPickUp()
    {
        //�κ��丮�� ������ ���� �ֱ�
        Inventory.AcquireItem(item);
        // ������Ʈ ����
        Destroy(this.gameObject);
    }


    //������ ȹ��� ������ ����
    public virtual void SaveItem()
    {
        theSaveAndLoad.SaveData();
    }


    //������ Ŭ�� ��
    public virtual void interact(DisplayImage currentDisplay)
    {
        CanPickUp();
    }
}
