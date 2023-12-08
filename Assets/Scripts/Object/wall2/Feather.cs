using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feather : MonoBehaviour
{
    
    private DisplayImage currentDisplay;
    private void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
    }


    void Update()
    {
        if (currentDisplay.CurrentWall != 2 || currentDisplay.CurrentState != DisplayImage.State.ChangedView)
        {
            Destroy(gameObject);
        }

        
    }
}
