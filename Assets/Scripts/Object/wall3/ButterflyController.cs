using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyController : MonoBehaviour
{


    public GameObject butterflyPrefab; //���� ������
    public GameObject spawnPoint; // ���� ����


    [SerializeField]
    private int poolSize = 30; //Ǯ ũ��

    public int butterflyCount;

    [SerializeField]
    private float coolDown = 0.5f, coolDownCounter; // ���� ��Ÿ��
    private List<GameObject> pools = new List<GameObject>(); //Ǯ



    public virtual void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject butterfly = Instantiate(butterflyPrefab, this.transform);
            butterfly.gameObject.SetActive(false);
            pools.Add(butterfly);
        }    // Ǯ �ʱ�ȭ

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
                    if (!pools[i].activeInHierarchy) //���̶�Ű â�� pools[i]�� ��Ȱ��ȭ�� ��
                    {
                        pools[i].transform.position = spawnPoint.transform.position;
                        pools[i].transform.rotation = spawnPoint.transform.rotation;
                        pools[i].SetActive(true); // ���� ����
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
            if (!pools[i].activeInHierarchy) //���̶�Ű â�� pools[i]�� ��Ȱ��ȭ�� ��
            {
                pools[i].transform.position = spawnPoint.transform.position;
                pools[i].transform.rotation = spawnPoint.transform.rotation;
                pools[i].SetActive(true); // ���� ����
                break;
            }
        }


    }





    public void allOff()
    {
        for (int i = 0; i < poolSize; i++)
        {
            if (pools[i].activeInHierarchy) //���̶�Ű â�� pools[i]�� Ȱ��ȭ�� ��
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
            if (pools[i].activeInHierarchy) //���̶�Ű â�� pools[i]�� Ȱ��ȭ�� ��
            {
                pools[i].SetActive(false);
                break;
            }
        }
    }
}
