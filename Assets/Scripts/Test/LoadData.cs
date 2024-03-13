using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadData : MonoBehaviour
{
    public static LoadData instance;
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


    public void ClickLoad()
    {
        Debug.Log("�ε�");
        StartCoroutine(LoadCoroutine());
    }


    IEnumerator LoadCoroutine()
    {
        
        SceneManager.LoadScene(sceneName); // �̱��� �ƴϿ����� ���⼭ Title �ı��Ǽ� �ؿ� �ڵ� ���� ����
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;


        while (!operation.isDone) // �ε��� ������ �ʾҴٸ�.. ���� while�����ٰ� operation.progress �̿��� �ε�ȭ�� ������൵ �ȴ�.
        {
            yield return null;
        }

        

        theSaveAndLoad = FindObjectOfType<SaveAndLoad>(); // ���� ���� SaveAndLoad
        theSaveAndLoad.LoadData();
       


        operation.allowSceneActivation = true;

        //gameObject.SetActive(false);  // "GameTitle"�� Canvas�� ��� ��Ȱ��ȭ
    }


}