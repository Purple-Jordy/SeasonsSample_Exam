using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title1 : MonoBehaviour
{
    public static Title1 instance;
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

        while (!operation.isDone) // �ε��� ������ �ʾҴٸ�.. ���� while�����ٰ� operation.progress �̿��� �ε�ȭ�� ������൵ �ȴ�.
        {
            yield return null;
        }

        theSaveAndLoad = FindObjectOfType<SaveAndLoad>(); // ���� ���� SaveAndLoad
        theSaveAndLoad.LoadData();

        
        //gameObject.SetActive(false);  // "GameTitle"�� Canvas�� ��� ��Ȱ��ȭ
    }


}
