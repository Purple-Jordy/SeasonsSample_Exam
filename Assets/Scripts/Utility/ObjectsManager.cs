using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsManager : MonoBehaviour
{
    private DisplayImage currentDisplay;

    public GameObject[] objectsToManage; //관리할 오브젝트 모음(배열)


    private void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
    }


    private void Update()
    {
        ManageObjects(); //화면에 따른 오브젝트 켜주기
    }


    void ManageObjects()
    {
        for(int i = 0; i < objectsToManage.Length; i++)
        {
            //오브젝트 매니지 안에 있는 이름이 현재 화면의 이미지(스프라이트)의 이름과 같으면 
            if (objectsToManage[i].name == currentDisplay.GetComponent<SpriteRenderer>().sprite.name)
            {
                objectsToManage[i].SetActive(true); // 그 오브젝트를 켜준다~
            }
            else
            {
                objectsToManage[i].SetActive(false);
            }
        }
    }

}
