﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BackgroundSpawner : MonoBehaviour
{
    public GameObject defaultPrefab;
    public GameObject hotPrefab;
    public GameObject coldPrefab;
    public string currentType;
    //public  string type;
    public GameManager GM;



    // The next x position that an background will spawn at
    float spawnNextX;

    //offset to makebackgrounds line up
    float offset = 4.35f;


    void Start()
    {
        spawnNextX = transform.position.x;
        currentType = "default";
    }

    void OnTriggerExit2D(Collider2D collision)
    {
     int type = Random.Range(0, 3);
            if (type == 0)
            {
                GameObject newThing = Instantiate(defaultPrefab, new Vector3(spawnNextX + offset, transform.position.y, transform.position.z), transform.rotation);
                newThing.transform.SetSiblingIndex(0);
                Sicken();
                //GM.stimulusText.text = null;
            }
            if (type == 1)
            {
                GameObject newThing = Instantiate(hotPrefab, new Vector3(spawnNextX + offset, transform.position.y, transform.position.z), transform.rotation);
                newThing.transform.SetSiblingIndex(0);
                currentType = "hot";
                //GM.stimulusText.text = "hot";
            }
             if(type == 2)
            {
                GameObject newThing = Instantiate(coldPrefab, new Vector3(spawnNextX + offset, transform.position.y, transform.position.z), transform.rotation);
                newThing.transform.SetSiblingIndex(0);
                currentType = "cold";
                //GM.stimulusText.text = "cold";
            }
    }

    //has a chance to set the stimulus to "sick" if on a default background
    public void Sicken()
    {
        int sick = Random.Range(0, 2);
        if (sick == 0)
        {
            currentType = "sick";

        }
        else
        {
            currentType = "default";
        }
        Debug.Log(currentType);
    }


}
