using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour, IInteractable
{
    #region PickUpItem
    public enum property { usable, displayable };

    public string DisplaySprite; //������ �̹���
    public string DisplayImage; //���� Ŭ���� ������ �̹���
    public string CombinationItem; 
    public string DisplayText; //�ؽ�Ʈ �̸�

    

    public property itemProperty;

    private GameObject InventorySlots;
    private TextMeshProUGUI itemText;
    private GameObject itemNameUI;
    #endregion


    // Ŭ���ϸ� ������ �Ⱦ�
    public void interact(DisplayImage currentDisplay)
    {
        ItemPickUp();
    }


    public virtual void Start()
    {
        itemNameUI = GameObject.Find("ItemNameUI");
        itemText = itemNameUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }


    // �Ⱦ� �Լ�
    public virtual void ItemPickUp()
    {
        InventorySlots = GameObject.Find("Slots");


        foreach (Transform slot in InventorySlots.transform)
        {
            //������ �ڽ� iteam�� ��������Ʈ �̸��� empty���(empty�� ���� ã�Ƽ� �ֱ�)
            if(slot.transform.GetChild(0).GetComponent<Image>().sprite.name == "empty_item")
            {
                slot.transform.GetChild(0).GetComponent<Animator>().SetTrigger("getItem");

                //item�� ��������Ʈ �̸����� ����
                slot.transform.GetChild(0).GetComponent<Image>().sprite =
                    Resources.Load<Sprite>("Inventory Items/" + DisplaySprite);

                //���Կ� ������ �Ӽ� �ο�
                //slot.GetComponent<Slot>().AssignProperty((int)itemProperty, DisplayImage, CombinationItem, DisplayText);

                //������ ȹ������ �� �̸� �����ֱ�
                itemNameUI.GetComponent<Animator>().SetTrigger("ShowName");
                itemText.text = DisplayText;

                //Ŭ���� ������ ����
                ItemDestroy();

                break;
            }

            
        }
    }


    public virtual void ItemDestroy()
    {
        Destroy(gameObject);
    }

}
