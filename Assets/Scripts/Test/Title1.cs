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
        Debug.Log("로드");
        StartCoroutine(LoadCoroutine());
    }


    IEnumerator LoadCoroutine()
    {
        
        SceneManager.LoadScene(sceneName); // 싱글톤 아니였으면 여기서 Title 파괴되서 밑에 코드 실행 못함
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while (!operation.isDone) // 로딩이 끝나지 않았다면.. 여기 while문에다가 operation.progress 이용해 로딩화면 만들어줘도 된다.
        {
            yield return null;
        }

        theSaveAndLoad = FindObjectOfType<SaveAndLoad>(); // 다음 씬의 SaveAndLoad
        theSaveAndLoad.LoadData();

        
        //gameObject.SetActive(false);  // "GameTitle"의 Canvas는 잠시 비활성화
    }


}
