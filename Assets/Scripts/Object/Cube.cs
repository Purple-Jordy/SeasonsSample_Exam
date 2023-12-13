using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Cube : MonoBehaviour
{
    public SceneFader fader;

    [SerializeField]
    private string loadToScene = "2SpringScene";

    // 위아래 흔들림 속도
    [SerializeField]
    private float verticalBobFrequency = 1f;

    // 위아래 흔들림 진폭량
    [SerializeField]
    private float bobingAmount = 1f;

    //회전
    [SerializeField]
    private float rotateSpeed = 10;

    // 처음 위치 
    private Vector3 startPosition;

   


    void Start()
    {
        // 초기화
        startPosition = transform.position;
    }

    void Update()
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

                    
                    //StartCoroutine(Click());
                    //Title1.instance.ClickLoad();

                    fader.FadeTo(loadToScene);
                }
            }

        }

        Rotate();

    }

    private void Rotate()
    {
        // 위 아래 흔들림
        float bobingAnimationPhase = Mathf.Sin(verticalBobFrequency * Time.time) * bobingAmount;
        transform.position = startPosition + Vector3.up * bobingAnimationPhase;

        //회전
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World);
    }


  
}
