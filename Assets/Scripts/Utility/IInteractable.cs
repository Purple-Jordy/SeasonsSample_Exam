using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable // 인터페이스 선언
{
    void interact(DisplayImage currentDisplay);
    //메서드 시그니처만 제공
    //IInteractable를 상속받는 클래스는 반드시 interact(DisplayImage currentDisplay) 클래스 내용을 구현해야 한다.
}
