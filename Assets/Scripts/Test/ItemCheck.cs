using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ItemCheck : MonoBehaviour
{


    private SaveData saveData = new SaveData();

    private string SAVE_DATA_DIRECTORY;  // 저장할 폴더 경로
    [SerializeField]
    private string SAVE_FILENAME = "/harvey.txt"; // 파일 이름

    public GameObject saveState1;


    public virtual void Start()
    {
        SAVE_DATA_DIRECTORY = Application.dataPath + "/Save/";

        if (!Directory.Exists(SAVE_DATA_DIRECTORY)) // 해당 경로가 존재하지 않는다면
            Directory.CreateDirectory(SAVE_DATA_DIRECTORY); // 폴더 생성(경로 생성)
    }

    private void OnEnable()
    {
        LoadData();
    }


    public virtual void SaveData()
    {
        //저장할 내용
        saveData.stringList.Add(saveState1.GetComponent<SpriteRenderer>().sprite.name);

     

        // 최종 전체 저장
        string json = JsonUtility.ToJson(saveData); // 제이슨화

        File.WriteAllText(SAVE_DATA_DIRECTORY + SAVE_FILENAME, json);

        Debug.Log($"{this.gameObject.name} Save");
        Debug.Log(json);
    }


    public virtual void LoadData()
    {
        if (File.Exists(SAVE_DATA_DIRECTORY + SAVE_FILENAME))
        {
            // 전체 읽어오기
            string loadJson = File.ReadAllText(SAVE_DATA_DIRECTORY + SAVE_FILENAME);
            saveData = JsonUtility.FromJson<SaveData>(loadJson);


            //불러올 내용
            


              saveState1.GetComponent<SpriteRenderer>().sprite.name = saveData.stringList[0];
            
            



            //

            Debug.Log($"{this.gameObject.name} Load");
        }
        else
            Debug.Log("세이브 파일이 없습니다.");
    }
}
