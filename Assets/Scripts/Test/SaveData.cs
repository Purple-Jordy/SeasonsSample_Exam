using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; //

[System.Serializable] // ����ȭ �ؾ� �� �ٷ� �����͵��� �����Ǿ� ���� ��ġ�� �а� ���Ⱑ ��������.
public class SaveData
{

    // ������ ����ȭ�� �Ұ���. ����ȭ�� �Ұ����� �ֵ��� �ִ�.
    public List<int> invenArrayNumber = new List<int>();
    public List<string> invenItemName = new List<string>();
    public List<Sprite> invenItemImage = new List<Sprite>();
    public List<string> invenItemText = new List<string>();
    //public List<string> invenItemChangeText = new List<string>();

    public List<bool> boolList = new List<bool>();
    public List<float> floatList = new List<float>();
    public List<string> stringList = new List<string>();



}
