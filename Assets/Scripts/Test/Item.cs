using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]
public class Item : ScriptableObject //게임 오브젝트에 붙일 필요없음
{
    public string itemName; // 아이템의 이름
    public Sprite itemImage; // 아이템의 이미지(인벤토리 안에서 띄울)
    public string itemText; //아이템의 한글 이름
    public string changeText;
}
