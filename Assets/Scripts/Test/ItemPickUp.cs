using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour, IInteractable
{
    public Item item;

    Inventory Inventory;
    private SaveAndLoad theSaveAndLoad;


    public virtual void Start()
    {
        Inventory = Inventory.Instance;

        Inventory.Instance.CheckItem(this.gameObject);
        theSaveAndLoad = FindObjectOfType<SaveAndLoad>();
    }


    public virtual void CanPickUp()
    {
        Inventory.AcquireItem(item);
        Destroy(this.gameObject);
    }


    public virtual void SaveItem()
    {
        theSaveAndLoad.SaveData();
    }


    public virtual void interact(DisplayImage currentDisplay)
    {
        CanPickUp();
        
    }
}
