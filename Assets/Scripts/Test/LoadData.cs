using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadData : MonoBehaviour
{
    public static LoadData instance; //�ν��Ͻ�ȭ
    public string sceneName = "2SpringScene";

    private SaveAndLoad theSaveAndLoad;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }


    public void ClickLoad() //�ε�
    {
        Debug.Log("�ε�");
        StartCoroutine(LoadCoroutine());
    }


    IEnumerator LoadCoroutine()
    {        

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName); //�񵿱������� �ε�
        

        while (!operation.isDone) // �ε��� ������ �ʾҴٸ�.. 
        {
            yield return null;
        }


        // ���� ���� SaveAndLoad�� �����ͼ� ������ �ε�
        theSaveAndLoad = FindObjectOfType<SaveAndLoad>(); 
        theSaveAndLoad.LoadData();
       

    }


}
