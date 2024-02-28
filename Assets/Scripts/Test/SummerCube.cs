using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummerCube : Cube
{
    public string loadToScene = "3SummerScene";

    // Update is called once per frame
    public override void Update()
    {
        //ȭ�� Ŭ�� üũ
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.gameObject);

                if (hit.transform.gameObject.tag == "Cube") // ť�� Ŭ�� ��
                {

                    
                    AudioManager.Instance.Play("OptionButton");
                    fader.FadeTo(loadToScene);
                }
            }

        }

        Rotate();
    }
}
