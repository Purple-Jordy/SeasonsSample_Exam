using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsManager : MonoBehaviour
{
    private DisplayImage currentDisplay;

    public GameObject[] objectsToManage;
    //public GameObject[] UIRenderObjects;


    private void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
        //RenderUI();
        
    }


    private void Update()
    {
        ManageObjects();
    }


    void ManageObjects()
    {
        for(int i = 0; i < objectsToManage.Length; i++)
        {
            //������Ʈ �Ŵ��� �ȿ� �ִ� �̸��� ���� ȭ��� ������ 
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


    /*void RenderUI()
    {
        for (int i = 0;i < UIRenderObjects.Length; i++)
        {
            UIRenderObjects[i].SetActive(false);
        }
    }*/

}
