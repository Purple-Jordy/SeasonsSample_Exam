using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockMove : MonoBehaviour, IInteractable
{
    private float angle = -30f;
    

    public void interact(DisplayImage currentDisplay)
    {
        //���������� 30���� �̵�
        this.transform.Rotate(new Vector3(0, 0, angle));

        //ȿ���� �÷���
        AudioManager.Instance.Play("lightOnOff");

    }

   
}
