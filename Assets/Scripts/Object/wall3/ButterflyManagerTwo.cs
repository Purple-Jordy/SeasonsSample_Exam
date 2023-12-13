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

        if (EggCup.eggDrop == true) //큐브가 사라지면
        {
            //화면이 키친1이 아니고 큐브획득했으면 나비 다 꺼주고 활동끝났다고 해주기
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
            if (EggCup.eggNum >= 4) //큐브 만들어지기 전, 알깨기 시작하고 있으면
            {
                if (displayImage.GetComponent<SpriteRenderer>().sprite.name == "wall3")
                {
                    // 나비 한마리 돌아다니게 
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
