using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummerCube : Cube
{
    public string loadToScene = "3SummerScene";

    // Update is called once per frame
    public override void Update()
    {
        //화면 클릭 체크
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.gameObject);

                if (hit.transform.gameObject.tag == "Cube") // 큐브 클릭 시
                {

                    
                    AudioManager.Instance.Play("OptionButton");
                    fader.FadeTo(loadToScene);
                }
            }

        }

        Rotate();
    }
}
