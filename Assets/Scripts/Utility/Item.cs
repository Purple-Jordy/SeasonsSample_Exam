using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]
public class Item : ScriptableObject //���� ������Ʈ�� ���� �ʿ����
{
    public string itemName; // �������� �̸�
    public Sprite itemImage; // �������� �̹���(�κ��丮 �ȿ��� ���)
    public string itemText; // UI�� ��� �������� �̸�
    public string changeText; //UI�� ��� �ٲ� ������ ������ �̸�
}