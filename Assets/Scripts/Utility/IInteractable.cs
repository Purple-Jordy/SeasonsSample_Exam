using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable // �������̽� ����
{
    void interact(DisplayImage currentDisplay);
    //�޼��� �ñ״�ó�� ����
    //IInteractable�� ��ӹ޴� Ŭ������ �ݵ�� interact(DisplayImage currentDisplay) Ŭ���� ������ �����ؾ� �Ѵ�.
}
