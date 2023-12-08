using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyController : MonoBehaviour
{


    public GameObject butterflyPrefab; //나비 프리팹
    public GameObject spawnPoint; // 생성 지점


    [SerializeField]
    private int poolSize = 30; //풀 크기

    public int butterflyCount;

    [SerializeField]
    private float coolDown = 0.5f, coolDownCounter; // 생성 쿨타임
    private List<GameObject> pools = new List<GameObject>(); //풀



    public virtual void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject butterfly = Instantiate(butterflyPrefab, this.transform);
            butterfly.gameObject.SetActive(false);
            pools.Add(butterfly);
        }    // 풀 초기화

        //coolDownCounter = coolDown;
        coolDownCounter = 0;


    }


    public virtual void Update()
    {

        MakeButterfly();

    }


    public void MakeButterfly()
    {
        if (butterflyCount > 0)
        {
            coolDownCounter -= Time.deltaTime;

            if (coolDownCounter < 0)
            {
                for (int i = 0; i < butterflyCount; i++)
                {
                    if (!pools[i].activeInHierarchy) //하이라키 창에 pools[i]가 비활성화일 때
                    {
                        pools[i].transform.position = spawnPoint.transform.position;
                        pools[i].transform.rotation = spawnPoint.transform.rotation;
                        pools[i].SetActive(true); // 나비 등장
                        break;
                    }
                }

                coolDownCounter = coolDown;
            }
        }


    }


    public void OutsideButterfly()
    {

        for (int i = 0; i < 2; i++)
        {
            if (!pools[i].activeInHierarchy) //하이라키 창에 pools[i]가 비활성화일 때
            {
                pools[i].transform.position = spawnPoint.transform.position;
                pools[i].transform.rotation = spawnPoint.transform.rotation;
                pools[i].SetActive(true); // 나비 등장
                break;
            }
        }


    }





    public void allOff()
    {
        for (int i = 0; i < poolSize; i++)
        {
            if (pools[i].activeInHierarchy) //하이라키 창에 pools[i]가 활성화일 때
            {
                pools[i].SetActive(false);
                break;
            }
        }
    }

    public void SelectOff(int offNum)
    {
        for (int i = 0; i < poolSize - offNum; i++)
        {
            if (pools[i].activeInHierarchy) //하이라키 창에 pools[i]가 활성화일 때
            {
                pools[i].SetActive(false);
                break;
            }
        }
    }
}
