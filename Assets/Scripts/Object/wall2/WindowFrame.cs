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


    //Ŭ�� �� ������ �۾�
    [SerializeField]
    private string lockText = "��⿡ �ʹ� ���ſ�";
    #endregion

    public GameObject photo4;
    public GameObject insideLaura;
    public GameObject insideShadow;
    private bool photoAppear = false; // ������ Ƣ�������


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
                //ȿ���� �÷���
                AudioManager.Instance.Play("curtainPhoto");
                photoAppear = true;
            }
            
        }

        //��ǳ��
        UIAnimator.Play("ShowItemNameAnim", -1, 0f);
        situationText.text = lockText;

    }


    void RandomAppear()
    {
        //50% : null, 30%: �ζ�, 20% �׸���
        Choose(new float[3] { 20f, 30f, 50f });

        float Choose(float[] probs)
        {

            float total = 0;

            // ���� ��Ҹ� �����ش� (100f)
            foreach (float elem in probs)
            {
                total += elem;
            }

            //��������Ʈ�� Random.value * ��� �÷�Ʈ�� �հ�
            //Random.value : 0.0���� 1.0 ������ ������ �ε� �Ҽ��� ���� �����մϴ�. 
            //�Ϲ����� ������ �ش� ����� ���Ͽ� 0�� ������ ���� ������ ���ڷ� ��ȯ�ϴ� ���Դϴ�.
            float randomPoint = Random.value * total;

            for (int i = 0; i < probs.Length; i++)
            {
                //��������Ʈ�� ��Һ��� ���� ���
                if (randomPoint < probs[i])
                {
                    switch (i)
                    {
                        case 0: //20f �ȿ� ��������Ʈ�� ������ ���
                            insideShadow.SetActive(true);
                            break;
                        case 1: //21f~50f �ȿ� ������ ���
                            insideLaura.SetActive(true);
                            break;
                        case 2: //51f~100f �ȿ� ������ ���
                            //null
                            break;

                    }

                    return i;
                }
                else //��������Ʈ�� ��Һ��� ū ���
                {
                    //��������Ʈ�� 30�̸� probs[0]=20f, 30-20=10; �׷��� case:1�� ���� �ȴ�
                    randomPoint -= probs[i];
                }
            }
            return probs.Length - 1;
        }
    }
}
