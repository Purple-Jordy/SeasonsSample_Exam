using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; // c# ����

public class SaveAndLoad : MonoBehaviour
{
    private SceneFader fader;

    // SaveData Ÿ���� ��ü �ν��Ͻ��� �ٷ� �������� �� �� �ν��Ͻ��� ��� ������ ������ �����͵��� ������ ��
    private SaveData saveData = new SaveData();

    private string SAVE_DATA_DIRECTORY;  // ������ ���� ���
    private string SAVE_FILENAME = "/SaveFile.txt"; // ���� �̸�
 
    private Inventory theInventory; // �κ��丮, ������ ���� �������� ���� �ʿ�


    void Start()
    {
        fader = FindObjectOfType<SceneFader>();

        //�����б�

        SAVE_DATA_DIRECTORY = Application.dataPath + "/Save/";

        if (!Directory.Exists(SAVE_DATA_DIRECTORY)) // �ش� ��ΰ� �������� �ʴ´ٸ�
            Directory.CreateDirectory(SAVE_DATA_DIRECTORY); // ���� ����(��� ����)

    }


    // �����ϱ�
    public void SaveData()
    {
        
        theInventory = FindObjectOfType<Inventory>();

        // �κ��丮 ���� ����(���ο� ���� �����ϱ� ����)
        saveData.invenArrayNumber.Clear();
        saveData.invenItemName.Clear();
        saveData.invenItemImage.Clear();
        saveData.invenItemText.Clear();


        // �κ��丮 ���� ����
        Slot[] slots = theInventory.GetSlots(); //�κ��丮 ���Ե��� �迭 ��������
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item != null)
            {
                saveData.invenArrayNumber.Add(i);
                saveData.invenItemName.Add(slots[i].item.itemName);
                
                saveData.invenItemImage.Add(slots[i].item.itemImage);
                saveData.invenItemText.Add(slots[i].item.itemText);

            }
        }

        saveData.boolList.Clear();

        saveData.boolList.Add(Spring.isPlay);
        saveData.boolList.Add(Feeding.isFeed);
        saveData.boolList.Add(Harvey.eggOnGround);
        saveData.boolList.Add(fireplace.woodHere);
        saveData.boolList.Add(fireplace.IsFire);
        saveData.boolList.Add(Candle.candleFire);
        saveData.boolList.Add(Photo.getPhoto1);
        saveData.boolList.Add(Photo.getPhoto3);
        saveData.boolList.Add(Photo.getPhoto4);
        saveData.boolList.Add(LightSwitch.lightOn);
        saveData.boolList.Add(kitchenPot.potOnSink);
        saveData.boolList.Add(ovenPot.potHere);
        saveData.boolList.Add(ovenPot.eggHere);
        saveData.boolList.Add(kitchenPot.waterInPot);
        saveData.boolList.Add(EggCup.eggHere);
        saveData.boolList.Add(EggCup.eggDrop);
        saveData.boolList.Add(MakeCube.cubeHere);
        saveData.boolList.Add(ovenPot.eggRipe);
     


        saveData.stringList.Clear();

        saveData.stringList.Add(Feeding.spriteName);



        saveData.floatList.Clear();

        saveData.floatList.Add(EggCup.eggNum);



        // ���� ��ü ����
        string json = JsonUtility.ToJson(saveData); // ���̽�ȭ

        File.WriteAllText(SAVE_DATA_DIRECTORY + SAVE_FILENAME, json); // ����

        Debug.Log("���� �Ϸ�");
        Debug.Log(json);
    }


    //������ �ε�
    public void LoadData()
    {
        if (File.Exists(SAVE_DATA_DIRECTORY + SAVE_FILENAME))
        {
            // ��ü �о����
            string loadJson = File.ReadAllText(SAVE_DATA_DIRECTORY + SAVE_FILENAME);
            saveData = JsonUtility.FromJson<SaveData>(loadJson);

            // ������ �� ó�� ������ �� �ѹ��� ���;��ϴ� ȿ��(ȭ���̳� ���� �ҷ����⿡���� ������ �ȵȴ�.)
            // �̹� ���Դ��� üũ�ϱ� ���ؼ� ���� ���� �ε�.
            Spring.isPlay = saveData.boolList[0];


            // �κ��丮 �ε�
            theInventory = FindObjectOfType<Inventory>();
            for (int i = 0; i < saveData.invenItemName.Count; i++)
            {
                theInventory.LoadToInven(saveData.invenArrayNumber[i], saveData.invenItemName[i]);
            }


            
            Feeding.isFeed = saveData.boolList[1];
            Harvey.eggOnGround = saveData.boolList[2];
            fireplace.woodHere = saveData.boolList[3];
            fireplace.IsFire = saveData.boolList[4];
            Candle.candleFire = saveData.boolList[5];
            Photo.getPhoto1 = saveData.boolList[6];
            Photo.getPhoto3 = saveData.boolList[7];
            Photo.getPhoto4 = saveData.boolList[8];
            LightSwitch.lightOn = saveData.boolList[9];
            kitchenPot.potOnSink = saveData.boolList[10];
            ovenPot.potHere = saveData.boolList[11];
            ovenPot.eggHere = saveData.boolList[12];
            kitchenPot.waterInPot = saveData.boolList[13];
            EggCup.eggHere = saveData.boolList[14];
            EggCup.eggDrop = saveData.boolList[15];
            MakeCube.cubeHere = saveData.boolList[16];
            ovenPot.eggRipe = saveData.boolList[17];



            Feeding.spriteName = saveData.stringList[0];


            EggCup.eggNum = saveData.floatList[0];



            Debug.Log("�ε� �Ϸ�");

        }
        else
            Debug.Log("���̺� ������ �����ϴ�.");

    }


    // ������ �ʱ�ȭ
    public void ResetData()
    {
        StartCoroutine(ClearData());
    }


    IEnumerator ClearData()
    {
        AudioManager.Instance.Play("OptionButton");

        saveData.invenArrayNumber.Clear();
        saveData.invenItemName.Clear();
        saveData.invenItemImage.Clear();
        saveData.invenItemText.Clear();

        saveData.boolList.Clear();

        Spring.isPlay = false;
        Feeding.isFeed = false;
        Harvey.eggOnGround = false;
        fireplace.woodHere = false;
        fireplace.IsFire = false;
        Candle.candleFire = false;
        Photo.getPhoto1 = false;
        Photo.getPhoto3 = false;
        Photo.getPhoto4 = false;
        LightSwitch.lightOn = false;
        kitchenPot.potOnSink = false;
        ovenPot.potHere = false;
        ovenPot.eggHere = false;
        kitchenPot.waterInPot = false;
        EggCup.eggHere = false;
        EggCup.eggDrop = false;
        MakeCube.cubeHere = false;
        ovenPot.eggRipe = false;


        saveData.stringList.Clear();
        saveData.floatList.Clear();


        // ���� ��ü ����
        string json = JsonUtility.ToJson(saveData); // ���̽�ȭ

        File.WriteAllText(SAVE_DATA_DIRECTORY + SAVE_FILENAME, json);

        Debug.Log("���� �Ϸ�");
        Debug.Log(json);

        //PlayerPrefs.DeleteKey("isPlay");

        yield return new WaitForSeconds(0.1f);

        fader.FadeTo("2SpringScene");
    }

}
