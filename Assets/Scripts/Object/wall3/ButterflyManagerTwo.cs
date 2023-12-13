using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyManagerTwo : ButterflyController
{

    private DisplayImage displayImage;
    public GameObject butterflyManagerOne;
    private ButterflyManager ManagerFirst;
    //public EggCup eggCup;


    public override void Start()
    {
        base.Start();

        displayImage = GameObject.Find("displayImage").GetComponent<DisplayImage>();
        ManagerFirst = butterflyManagerOne.GetComponent<ButterflyManager>();
        
    }

    public override void Update()
    {
        base.Update();

        if (EggCup.eggDrop == true) //ť�갡 �������
        {
            //ȭ���� Űģ1�� �ƴϰ� ť��ȹ�������� ���� �� ���ְ� Ȱ�������ٰ� ���ֱ�
            if (displayImage.GetComponent<SpriteRenderer>().sprite.name != "kitchen1")
            {
                butterflyManagerOne.SetActive(false);
            }

            if (!butterflyManagerOne.activeSelf)
            {
                if (displayImage.GetComponent<SpriteRenderer>().sprite.name == "kitchen1"
                    || displayImage.GetComponent<SpriteRenderer>().sprite.name == "wall3")
                {
                    //butterflyCount = 2;
                    this.transform.GetChild(0).gameObject.SetActive(true);
                    this.transform.GetChild(1).gameObject.SetActive(true);
                }
                else
                {
                    this.transform.GetChild(0).gameObject.SetActive(false);
                    this.transform.GetChild(1).gameObject.SetActive(false);
                }
            }
            

        }
        else
        {
            if (EggCup.eggNum >= 4) //ť�� ��������� ��, �˱��� �����ϰ� ������
            {
                if (displayImage.GetComponent<SpriteRenderer>().sprite.name == "wall3")
                {
                    // ���� �Ѹ��� ���ƴٴϰ� 
                    this.transform.GetChild(0).gameObject.SetActive(true); 

                }
                else
                {
                    this.transform.GetChild(0).gameObject.SetActive(false);

                }
            }
        }


    }



}
