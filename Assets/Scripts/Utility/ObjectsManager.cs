using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsManager : MonoBehaviour
{
    private DisplayImage currentDisplay;

    public GameObject[] objectsToManage; //������ ������Ʈ ����(�迭)


    private void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
    }


    private void Update()
    {
        ManageObjects(); //ȭ�鿡 ���� ������Ʈ ���ֱ�
    }


    void ManageObjects()
    {
        for(int i = 0; i < objectsToManage.Length; i++)
        {
            //������Ʈ �Ŵ��� �ȿ� �ִ� �̸��� ���� ȭ���� �̹���(��������Ʈ)�� �̸��� ������ 
            if (objectsToManage[i].name == currentDisplay.GetComponent<SpriteRenderer>().sprite.name)
            {
                objectsToManage[i].SetActive(true); // �� ������Ʈ�� ���ش�~
            }
            else
            {
                objectsToManage[i].SetActive(false);
            }
        }
    }

}
