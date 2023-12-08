using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Feeding : MonoBehaviour, IInteractable
{
   
    private Inventory inventory;

    // 상호작용할 아이템 이름
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
                    // 먹이를 두고 인벤토리 비우고 save 해주기
                    inventory.currentSelectedSlot.GetComponent<Slot>().ClearSlot();
                    isFeed = true;
                    //SaveAndLoad.SaveData();
                    
                }
                
            }

        }
    }
}
