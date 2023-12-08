using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioWaypoints : MonoBehaviour
{
    // 이동 포인트의 배열
    public static Transform[] points;

    private void Awake()
    {
        // transform.childCount : 자식 오브젝트의 갯수 불러오기
        points = new Transform[this.transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            // transform.GetChild(i) : 번호 순으로 자식 오브젝트 찾기 
            points[i] = this.transform.GetChild(i);
        }
    }
}
