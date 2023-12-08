using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioFrequency : MonoBehaviour
{
    // 이동속도
    public float speed = 10f;

    // 이동 목표 위치
    private Vector3 targetPosition;

    //WayPoints 배열의 인덱스 변수
    public int pointsIndex = 0;



    void Update()
    {
        SetRightPoint();
    }


    //주파수 이동
    void SetRightPoint()
    {

        // 종점 확인
        if (pointsIndex != RadioWaypoints.points.Length || pointsIndex >= 0)
        {
            // 타겟 위치는 WayPoints 배열의 인덱스 변수들의 위치
            targetPosition = RadioWaypoints.points[pointsIndex].position;

            // 방향 구하기 (타겟 위치 - 내 위치)
            Vector3 dir = targetPosition - transform.position;

            if(dir.magnitude < 0.1f)
            {
                this.transform.position = targetPosition;
            }
            else
            {
                // 방향, 속도 구하고 절대 좌표 기준으로 이동
                this.transform.Translate(dir.normalized * Time.deltaTime * speed, Space.World);
            }
            
        }

    }


    

}
