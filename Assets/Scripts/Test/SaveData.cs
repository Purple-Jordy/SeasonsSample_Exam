using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; //

[System.Serializable] // 직렬화 해야 한 줄로 데이터들이 나열되어 저장 장치에 읽고 쓰기가 쉬워진다.
public class SaveData
{
    // 슬롯은 직렬화가 불가능. 직렬화가 불가능한 애들이 있다.
    
    // 인벤토리 관련
    public List<int> invenArrayNumber = new List<int>(); // 인벤토리 숫자
    public List<string> invenItemName = new List<string>(); // 인벤토리 아이템 이름
    public List<Sprite> invenItemImage = new List<Sprite>(); // 인벤토리 아이템 이미지
    public List<string> invenItemText = new List<string>(); // 인벤토리 아이템 설명

    // 아이템(오브젝트) 관련
    public List<bool> boolList = new List<bool>(); 
    public List<float> floatList = new List<float>();
    public List<string> stringList = new List<string>();

}
