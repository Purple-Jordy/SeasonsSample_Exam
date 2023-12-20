using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockMove : MonoBehaviour, IInteractable
{
    private float angle = -30f;
    

    public void interact(DisplayImage currentDisplay)
    {
        //오른쪽으로 30도씩 이동
        this.transform.Rotate(new Vector3(0, 0, angle));

        //효과음 플레이
        AudioManager.Instance.Play("lightOnOff");

    }

   
}
