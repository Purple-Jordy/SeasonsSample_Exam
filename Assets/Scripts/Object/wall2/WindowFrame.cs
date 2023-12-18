using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WindowFrame : MonoBehaviour, IInteractable
{

    #region Situation

    private GameObject situationUI;
    private Animator UIAnimator;
    private TextMeshProUGUI situationText;


    //클릭 시 나오는 글씨
    [SerializeField]
    private string lockText = "들기에 너무 무거움";
    #endregion

    public GameObject photo4;
    public GameObject insideLaura;
    public GameObject insideShadow;
    private bool photoAppear = false; // 사진이 튀어나갔는지


    public void Start()
    {
        situationUI = GameObject.Find("situationUI");
        UIAnimator = situationUI.GetComponent<Animator>();
        situationText = situationUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

    }

    private void Update()
    {
        if (Photo.getPhoto4)
        {
            Destroy(photo4);
        }
    }


    private void OnEnable()
    {
        RandomAppear();
    }


    private void OnDisable()
    {
        insideLaura.GetComponent<Animator>().Rebind();
        insideLaura.SetActive(false);
        insideShadow.SetActive(false);
    }


    public void interact(DisplayImage currentDisplay)
    {
        if(photoAppear == false)
        {
            if(photo4 != null)
            {
                photo4.SetActive(true);
                photo4.GetComponent<Animator>().SetTrigger("Click");
                //효과음 플레이
                AudioManager.Instance.Play("curtainPhoto");
                photoAppear = true;
            }
            
        }

        //말풍선
        UIAnimator.Play("ShowItemNameAnim", -1, 0f);
        situationText.text = lockText;

    }


    void RandomAppear()
    {
        //50% : null, 30%: 로라, 20% 그림자
        Choose(new float[3] { 20f, 30f, 50f });

        float Choose(float[] probs)
        {

            float total = 0;

            // 각각 요소를 더해준다 (100f)
            foreach (float elem in probs)
            {
                total += elem;
            }

            //랜덤포인트는 Random.value * 모든 플로트의 합계
            //Random.value : 0.0에서 1.0 사이의 임의의 부동 소수점 수를 제공합니다. 
            //일반적인 사용법은 해당 결과를 곱하여 0과 선택한 범위 사이의 숫자로 변환하는 것입니다.
            float randomPoint = Random.value * total;

            for (int i = 0; i < probs.Length; i++)
            {
                //랜덤포인트가 요소보다 작은 경우
                if (randomPoint < probs[i])
                {
                    switch (i)
                    {
                        case 0: //20f 안에 랜덤포인트가 생성된 경우
                            insideShadow.SetActive(true);
                            break;
                        case 1: //21f~50f 안에 생성된 경우
                            insideLaura.SetActive(true);
                            break;
                        case 2: //51f~100f 안에 생성된 경우
                            //null
                            break;

                    }

                    return i;
                }
                else //랜덤포인트가 요소보다 큰 경우
                {
                    //랜덤포인트가 30이면 probs[0]=20f, 30-20=10; 그래서 case:1로 들어가게 된다
                    randomPoint -= probs[i];
                }
            }
            return probs.Length - 1;
        }
    }
}
