using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkDoor : MonoBehaviour, IInteractable
{

    public GameObject sinkDoor;



    //클릭하면 온오프 바꾸기
    public void interact(DisplayImage currentDisplay)
    {         
        sinkDoor.SetActive(true);
        this.gameObject.SetActive(false);

        //효과음 플레이
        AudioManager.Instance.Play("lightOnOff");
    }

}
