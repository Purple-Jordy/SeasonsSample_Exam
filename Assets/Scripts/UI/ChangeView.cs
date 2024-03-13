using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeView : MonoBehaviour, IInteractable //인터페이스 상속
{
    
    public string SpriteName; // 바꿀 화면 이미지(sprite) 이름


    //화면 바뀌는 오브젝트 클릭시(인터페이스 상속)
    public void interact(DisplayImage currentDisplay)
    {
        //이미지 교체
        currentDisplay.GetComponent<SpriteRenderer>().sprite =
            Resources.Load<Sprite>("Sprites/" + SpriteName);

        //상태 교체(changedView)
        currentDisplay.CurrentState = DisplayImage.State.ChangedView;

    }


}
