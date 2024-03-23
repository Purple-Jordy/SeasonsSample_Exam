using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; //

[System.Serializable] // ����ȭ �ؾ� �� �ٷ� �����͵��� �����Ǿ� ���� ��ġ�� �а� ���Ⱑ ��������.
public class SaveData
{
    // ������ ����ȭ�� �Ұ���. ����ȭ�� �Ұ����� �ֵ��� �ִ�.
    
    // �κ��丮 ����
    public List<int> invenArrayNumber = new List<int>(); // �κ��丮 ����
    public List<string> invenItemName = new List<string>(); // �κ��丮 ������ �̸�
    public List<Sprite> invenItemImage = new List<Sprite>(); // �κ��丮 ������ �̹���
    public List<string> invenItemText = new List<string>(); // �κ��丮 ������ ����

    // ������(������Ʈ) ����
    public List<bool> boolList = new List<bool>(); 
    public List<float> floatList = new List<float>();
    public List<string> stringList = new List<string>();

}
