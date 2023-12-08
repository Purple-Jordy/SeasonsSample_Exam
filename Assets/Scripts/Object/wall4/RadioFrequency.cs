using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioFrequency : MonoBehaviour
{
    // �̵��ӵ�
    public float speed = 10f;

    // �̵� ��ǥ ��ġ
    private Vector3 targetPosition;

    //WayPoints �迭�� �ε��� ����
    public int pointsIndex = 0;



    void Update()
    {
        SetRightPoint();
    }


    //���ļ� �̵�
    void SetRightPoint()
    {

        // ���� Ȯ��
        if (pointsIndex != RadioWaypoints.points.Length || pointsIndex >= 0)
        {
            // Ÿ�� ��ġ�� WayPoints �迭�� �ε��� �������� ��ġ
            targetPosition = RadioWaypoints.points[pointsIndex].position;

            // ���� ���ϱ� (Ÿ�� ��ġ - �� ��ġ)
            Vector3 dir = targetPosition - transform.position;

            if(dir.magnitude < 0.1f)
            {
                this.transform.position = targetPosition;
            }
            else
            {
                // ����, �ӵ� ���ϰ� ���� ��ǥ �������� �̵�
                this.transform.Translate(dir.normalized * Time.deltaTime * speed, Space.World);
            }
            
        }

    }


    

}
