using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkDoorManager : MonoBehaviour
{

    public GameObject sinkDoor1Close;
    public GameObject sinkDoor2Close;
    public GameObject sinkDoor1Open;
    public GameObject sinkDoor2Open;


    private void OnEnable()
    {
        sinkDoor1Close.SetActive(true);
        sinkDoor2Close.SetActive(true);
        sinkDoor1Open.SetActive(false);
        sinkDoor2Open.SetActive(false);
    }


}
