using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeView : MonoBehaviour, IInteractable //�������̽� ���
{
    
    public string SpriteName; // �ٲ� ȭ�� �̹���(sprite) �̸�


    //ȭ�� �ٲ�� ������Ʈ Ŭ����(�������̽� ���)
    public void interact(DisplayImage currentDisplay)
    {
        //�̹��� ��ü
        currentDisplay.GetComponent<SpriteRenderer>().sprite =
            Resources.Load<Sprite>("Sprites/" + SpriteName);

        //���� ��ü(changedView)
        currentDisplay.CurrentState = DisplayImage.State.ChangedView;

    }


}
