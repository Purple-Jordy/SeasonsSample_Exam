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

    private LoadData loadData; // 씬 데이터 관련


    public void Start()
    {
        // 초기화
        startPosition = transform.position;
        loadData = FindObjectOfType<LoadData>(); // 오브젝트 찾기
    }


    public virtual void Update()
    {
        //화면 클릭 체크
        if (Input.GetMouseButtonDown(0))
        {
            // 카메라에서 마우스 포인터 위치로 레이를 발사
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit; // 객체와 Ray의 충돌에 대한 결과 정보를 저장하는 구조체

            if (Physics.Raycast(ray, out hit)) //충돌이 있다면
            {
                Debug.Log(hit.transform.gameObject);

                if (hit.transform.gameObject.tag == "Cube") // 충돌체의 태그가 큐브라면
                {
                    AudioManager.Instance.Play("OptionButton"); //효과음 재생
                    StartCoroutine(startGame()); // startGame 코루틴 시작

                }
            }

        }

        // 큐브 회전
        Rotate();

    }


    // 큐브 회전
    public void Rotate()
    {
        // 위 아래 흔들림
        float bobingAnimationPhase = Mathf.Sin(verticalBobFrequency * Time.time) * bobingAmount;
        transform.position = startPosition + Vector3.up * bobingAnimationPhase;

        // 큐브 회전
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World);
    }


    // 게임 시작 코루틴 
    IEnumerator startGame()
    {

        fader.FadeTo(1f); // 페이드 아웃

        yield return new WaitForSeconds(1f);

        loadData.ClickLoad(); //데이터 불러오면서 springScene으로 이동

    }
  
}
