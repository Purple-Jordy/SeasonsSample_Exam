using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Feeding : MonoBehaviour, IInteractable
{
   
    private Inventory inventory;

    // ��ȣ�ۿ��� ������ �̸�
    public string UnlockItem;

    public static bool isFeed = false;
    public static string spriteName;

    public SaveAndLoad SaveAndLoad;
    private SpriteRenderer render;



    private void Start()
    {
        inventory = Inventory.Instance;
        render = gameObject.GetComponent<SpriteRenderer>();
    }


    private void Update()
    {
        if(render.sprite != null)
        {
            spriteName = render.sprite.name;
            render.sprite.name = spriteName;
        }
        
        if(isFeed)
        {
            render.sprite = Resources.Load<Sprite>("Object/" + UnlockItem);
        }
    }

    


    public void interact(DisplayImage currentDisplay)
    {
        if (inventory.currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem)
        {
            if (inventory.currentSelectedSlot.GetComponent<Slot>().chooseItem == true)
            {
                if (!isFeed)
                {
                    // ���̸� �ΰ� �κ��丮 ���� save ���ֱ�
                    inventory.currentSelectedSlot.GetComponent<Slot>().ClearSlot();
                    isFeed = true;
                    //SaveAndLoad.SaveData();
                    
                }
                
            }

        }
    }
}
