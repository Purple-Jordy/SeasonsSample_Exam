using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour, IInteractable //인터페이스 상속
{
    public Item item; //애셋 아이템

    Inventory Inventory;
    private SaveAndLoad theSaveAndLoad;


    public virtual void Start()
    {
        Inventory = Inventory.Instance;
        Inventory.Instance.CheckItem(this.gameObject); // 저장 정보 확인
        theSaveAndLoad = FindObjectOfType<SaveAndLoad>();
    }


    // 아이템 획득
    public virtual void CanPickUp()
    {
        //인벤토리에 아이템 정보 주기
        Inventory.AcquireItem(item);
        // 오브젝트 삭제
        Destroy(this.gameObject);
    }


    //아이템 획득시 데이터 저장
    public virtual void SaveItem()
    {
        theSaveAndLoad.SaveData();
    }


    //아이템 클릭 시
    public virtual void interact(DisplayImage currentDisplay)
    {
        CanPickUp();
    }
}
