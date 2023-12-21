using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveAndLoad : MonoBehaviour
{
    private SceneFader fader;
    private SaveData saveData = new SaveData();

    private string SAVE_DATA_DIRECTORY;  // 저장할 폴더 경로
    private string SAVE_FILENAME = "/SaveFile.txt"; // 파일 이름
 
    private Inventory theInventory; // 인벤토리, 퀵슬롯 상태 가져오기 위해 필요



    void Start()
    {
        fader = FindObjectOfType<SceneFader>();

        SAVE_DATA_DIRECTORY = Application.dataPath + "/Save/";

        if (!Directory.Exists(SAVE_DATA_DIRECTORY)) // 해당 경로가 존재하지 않는다면
            Directory.CreateDirectory(SAVE_DATA_DIRECTORY); // 폴더 생성(경로 생성)
    }


    public void SaveData()
    {

        theInventory = FindObjectOfType<Inventory>();

        saveData.invenArrayNumber.Clear();
        saveData.invenItemName.Clear();
        saveData.invenItemImage.Clear();
        saveData.invenItemText.Clear();
        //saveData.invenItemChangeText.Clear();


        // 인벤토리 정보 저장
        Slot[] slots = theInventory.GetSlots();
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item != null)
            {
                saveData.invenArrayNumber.Add(i);
                saveData.invenItemName.Add(slots[i].item.itemName);
                
                saveData.invenItemImage.Add(slots[i].item.itemImage);
                saveData.invenItemText.Add(slots[i].item.itemText);
                //saveData.invenItemChangeText.Add(slots[i].item.changeText);
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



        // 최종 전체 저장
        string json = JsonUtility.ToJson(saveData); // 제이슨화

        File.WriteAllText(SAVE_DATA_DIRECTORY + SAVE_FILENAME, json);

        Debug.Log("저장 완료");
        Debug.Log(json);
    }


    public void LoadData()
    {
        if (File.Exists(SAVE_DATA_DIRECTORY + SAVE_FILENAME))
        {
            // 전체 읽어오기
            string loadJson = File.ReadAllText(SAVE_DATA_DIRECTORY + SAVE_FILENAME);
            saveData = JsonUtility.FromJson<SaveData>(loadJson);


            theInventory = FindObjectOfType<Inventory>();


            // 인벤토리 로드
            for (int i = 0; i < saveData.invenItemName.Count; i++)
            {
                theInventory.LoadToInven(saveData.invenArrayNumber[i], saveData.invenItemName[i]);

            }


            Spring.isPlay = saveData.boolList[0];
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



            Debug.Log("로드 완료");

        }
        else
            Debug.Log("세이브 파일이 없습니다.");

    }


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
        saveData.stringList.Clear();
        saveData.floatList.Clear();


        // 최종 전체 저장
        string json = JsonUtility.ToJson(saveData); // 제이슨화

        File.WriteAllText(SAVE_DATA_DIRECTORY + SAVE_FILENAME, json);

        Debug.Log("저장 완료");
        Debug.Log(json);

        PlayerPrefs.DeleteKey("isPlay");

        yield return new WaitForSeconds(0.1f);

        fader.FadeTo("2SpringScene");
    }
}
