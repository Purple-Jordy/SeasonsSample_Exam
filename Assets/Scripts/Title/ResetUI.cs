using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetUI : MonoBehaviour
{

    public GameObject askUI;
    private Animator animator;


    private void Start()
    {
        animator = askUI.GetComponent<Animator>();  
    }


    // 초기화 버튼 누를 시, 다시 한 번 묻는 창 나오게
    public void OpenAsk()
    {
        AudioManager.Instance.Play("OptionButton"); //효과음 재생
        askUI.SetActive(true); // 다시 한 번 물어보는 창 켜기
    }


    // 아니오 버튼 누를 시
    public void NoButton()
    {
        AudioManager.Instance.Play("OptionButton"); //효과음 재생
        StartCoroutine(AskOff()); // AskOff 코루틴 시작

        // 예 버튼을 누를 시 데이터 관련 스크립트 saveAndLoad에서 초기화
    }


    IEnumerator AskOff()
    {
        animator.SetBool("ask", true); // 꺼지는 애니메이션 재생

        yield return new WaitForSeconds(0.3f);

        askUI.SetActive(false); // 물어보는 창 끄기
    }
}
