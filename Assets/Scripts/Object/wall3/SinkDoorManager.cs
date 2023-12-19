using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkDoorManager : MonoBehaviour
{

    public GameObject sinkDoor1Close;
    public GameObject sinkDoor2Close;
    public GameObject sinkDoor1Open;
    public GameObject sinkDoor2Open;

    public GameObject OvenPot;
    public GameObject KitchenPot;
    public GameObject eggCup;
    public GameObject blackCube;


    private void OnEnable()
    {
        sinkDoor1Close.SetActive(true);
        sinkDoor2Close.SetActive(true);
        sinkDoor1Open.SetActive(false);
        sinkDoor2Open.SetActive(false);
    }


    private void Update()
    {
        if (kitchenPot.potOnSink)
        {
            KitchenPot.SetActive(true);
        }
        else
        {
            KitchenPot.SetActive(false);
        }

        if (ovenPot.potHere)
        {
            OvenPot.SetActive(true);
        }
        else
        {
            OvenPot.SetActive(false);
        }

        if (EggCup.eggHere)
        {
            eggCup.GetComponent<SpriteRenderer>().enabled = true;
            eggCup.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("object/egg" + (EggCup.eggNum));
        }
        else
        {
            eggCup.GetComponent<SpriteRenderer>().enabled = false;
        }

        if (EggCup.blackCubeHere)
        {
            if(blackCube != null)
            {
                blackCube.SetActive(true);
            }

        }
        else
        {
            blackCube.SetActive(false);
        }
    }

}
