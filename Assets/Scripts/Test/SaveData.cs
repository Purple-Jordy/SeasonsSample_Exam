using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; //

[System.Serializable] // 직렬화 해야 한 줄로 데이터들이 나열되어 저장 장치에 읽고 쓰기가 쉬워진다.
public class SaveData
{

    // 슬롯은 직렬화가 불가능. 직렬화가 불가능한 애들이 있다.
    public List<int> invenArrayNumber = new List<int>();
    public List<string> invenItemName = new List<string>();
    public List<Sprite> invenItemImage = new List<Sprite>();
    public List<string> invenItemText = new List<string>();
    //public List<string> invenItemChangeText = new List<string>();

    public List<bool> boolList = new List<bool>();
    public List<float> floatList = new List<float>();
    public List<string> stringList = new List<string>();



}
