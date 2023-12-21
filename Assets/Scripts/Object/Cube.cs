using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Cube : MonoBehaviour
{
    public SceneFader fader;

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

    private Title1 title1;


    public void Start()
    {
        // 초기화
        startPosition = transform.position;
        title1 = FindObjectOfType<Title1>();
    }


    public virtual void Update()
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
                    StartCoroutine(startGame());
                    
                }
            }

        }

        Rotate();

    }


    public void Rotate()
    {
        // 위 아래 흔들림
        float bobingAnimationPhase = Mathf.Sin(verticalBobFrequency * Time.time) * bobingAmount;
        transform.position = startPosition + Vector3.up * bobingAnimationPhase;

        //회전
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World);
    }


    IEnumerator startGame()
    {

        fader.FadeTo();

        yield return new WaitForSeconds(1f);

        title1.ClickLoad();

    }
  
}
