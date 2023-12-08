using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioWaypoints : MonoBehaviour
{
    // �̵� ����Ʈ�� �迭
    public static Transform[] points;

    private void Awake()
    {
        // transform.childCount : �ڽ� ������Ʈ�� ���� �ҷ�����
        points = new Transform[this.transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            // transform.GetChild(i) : ��ȣ ������ �ڽ� ������Ʈ ã�� 
            points[i] = this.transform.GetChild(i);
        }
    }
}
