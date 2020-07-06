using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{

    public GameObject defaultPrefab;


    // The next y position that an background will spawn at
    float spawnNextY;

    //offset to makebackgrounds line up
    float offset = 3.5f;


    void Start()
    {
        spawnNextY = transform.position.y;
    }

    void OnTriggerExit2D(Collider2D collision)
        {   
         GameObject newThing = Instantiate(defaultPrefab, new Vector3(transform.position.x, spawnNextY + offset, transform.position.z), transform.rotation);
         newThing.transform.SetSiblingIndex(1);
            
        }
    
}
