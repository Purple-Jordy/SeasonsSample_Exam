using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ItemCheck : MonoBehaviour
{


    private SaveData saveData = new SaveData();

    private string SAVE_DATA_DIRECTORY;  // ������ ���� ���
    [SerializeField]
    private string SAVE_FILENAME = "/harvey.txt"; // ���� �̸�

    public GameObject saveState1;


    public virtual void Start()
    {
        SAVE_DATA_DIRECTORY = Application.dataPath + "/Save/";

        if (!Directory.Exists(SAVE_DATA_DIRECTORY)) // �ش� ��ΰ� �������� �ʴ´ٸ�
            Directory.CreateDirectory(SAVE_DATA_DIRECTORY); // ���� ����(��� ����)
    }

    private void OnEnable()
    {
        LoadData();
    }


    public virtual void SaveData()
    {
        //������ ����
        saveData.stringList.Add(saveState1.GetComponent<SpriteRenderer>().sprite.name);

     

        // ���� ��ü ����
        string json = JsonUtility.ToJson(saveData); // ���̽�ȭ

        File.WriteAllText(SAVE_DATA_DIRECTORY + SAVE_FILENAME, json);

        Debug.Log($"{this.gameObject.name} Save");
        Debug.Log(json);
    }


    public virtual void LoadData()
    {
        if (File.Exists(SAVE_DATA_DIRECTORY + SAVE_FILENAME))
        {
            // ��ü �о����
            string loadJson = File.ReadAllText(SAVE_DATA_DIRECTORY + SAVE_FILENAME);
            saveData = JsonUtility.FromJson<SaveData>(loadJson);


            //�ҷ��� ����
            


              saveState1.GetComponent<SpriteRenderer>().sprite.name = saveData.stringList[0];
            
            



            //

            Debug.Log($"{this.gameObject.name} Load");
        }
        else
            Debug.Log("���̺� ������ �����ϴ�.");
    }
}
