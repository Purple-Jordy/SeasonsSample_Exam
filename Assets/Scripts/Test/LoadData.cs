using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadData : MonoBehaviour
{
    public static LoadData instance; //인스턴스화
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


    public void ClickLoad() //로드
    {
        Debug.Log("로드");
        StartCoroutine(LoadCoroutine());
    }


    IEnumerator LoadCoroutine()
    {        

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName); //비동기적으로 로딩
        

        while (!operation.isDone) // 로딩이 끝나지 않았다면.. 
        {
            yield return null;
        }


        // 다음 씬의 SaveAndLoad를 가져와서 데이터 로드
        theSaveAndLoad = FindObjectOfType<SaveAndLoad>(); 
        theSaveAndLoad.LoadData();
       

    }


}
