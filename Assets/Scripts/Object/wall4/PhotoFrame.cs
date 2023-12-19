using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoFrame : MonoBehaviour, IInteractable
{
    //액자 움직임 애니메이션
    private Animator animator;

    //액자 아래 확인(사진에서 확인용)
    public bool frameDown = false;

    // 큐브 확인
    //private MakeCube makeCube;
    // 벽난로 불 확인
    //private fireplace fireplace;

    private GameObject photo;


    void Start()
    {
        animator = GetComponent<Animator>();

        //fireplace = GameObject.Find("fireplace").GetComponent<fireplace>();
        //makeCube = GameObject.Find("MakeCube").GetComponent<MakeCube>();

        photo = this.transform.GetChild(0).gameObject;
    }


    // 오브젝트 클릭하면
    public void interact(DisplayImage currentDisplay)
    {
        //화면이 zoom 상태일때만 움직이는 애니메이션 재생
        if (currentDisplay.CurrentState == DisplayImage.State.zoom)
        {
            //큐브랑 불이 둘 다 있으면 화면은 계속 내려가 있는 상태
            if(fireplace.IsFire == true && MakeCube.cubeHere == true)
            {
                if (animator.GetBool("IsDown") == false)
                {
                    animator.SetBool("IsDown", true);
                    //효과음 플레이
                    AudioManager.Instance.Play("frameDown");
                    frameDown = true;
                }
            }
            else
            {

                if (animator.GetBool("IsDown") == false)
                {
                    animator.SetBool("IsDown", true);
                    //효과음 플레이
                    AudioManager.Instance.Play("frameDown");
                    frameDown = true;
                }
                else
                {
                    animator.SetBool("IsDown", false);
                    AudioManager.Instance.Play("frameDown");
                    frameDown = false;
                }
            }


        }

    }


}
