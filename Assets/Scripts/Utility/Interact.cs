using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    private DisplayImage currentDisplay;


    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
    }


    void Update()
    {
        // 마우스를 클릭했을 경우
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 rayPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(rayPosition, Vector2.zero, 10);

            // hit의 태그가 Interactable일 경우
            if (hit && hit.transform.tag == "Interactable")
            {
                //hit의 인터페이스 IInteractable의 interact(currentDisplay) 실행
                hit.transform.GetComponent<IInteractable>().interact(currentDisplay);
            }
        }
    }

    
}
