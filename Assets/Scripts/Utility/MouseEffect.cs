using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEffect : MonoBehaviour
{
    public GameObject circlePrefab;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mPosition =Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mPosition.z = 0;
        Instantiate(circlePrefab, mPosition, Quaternion.identity);
    }
}
