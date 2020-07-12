using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BackgroundSpawner : MonoBehaviour
{
    public GameObject defaultPrefab;
    public GameObject hotPrefab;
    public GameObject coldPrefab;
    public string currentType;
    public GameManager GM;
    public Zombie zombiePrefab;
    public float timer;
    public float zombieSpawnTime;
    public float speedIncrease;

    // The next x position that an background will spawn at
    float spawnNextX;

    //offset to makebackgrounds line up
    float offset = 4.35f;


    void Start()
    {
        spawnNextX = transform.position.x;
        currentType = "default";
        
    }

    private void Update()
    {
        
    }

    void OnTriggerExit2D(Collider2D collision)
    {
     int type = Random.Range(0, 3);
            if (type == 0)
            {
                GameObject newThing = Instantiate(defaultPrefab, new Vector3(spawnNextX + offset, transform.position.y, transform.position.z), transform.rotation);
                newThing.transform.SetSiblingIndex(0);
                Sicken();
                SpeedUp();
            }
            if (type == 1)
            {
                GameObject newThing = Instantiate(hotPrefab, new Vector3(spawnNextX + offset, transform.position.y, transform.position.z), transform.rotation);
                newThing.transform.SetSiblingIndex(0);
                currentType = "hot";
                SpeedUp();
        }
        if (type == 2)
            {
                GameObject newThing = Instantiate(coldPrefab, new Vector3(spawnNextX + offset, transform.position.y, transform.position.z), transform.rotation);
                newThing.transform.SetSiblingIndex(0);
                currentType = "cold";
                SpeedUp();
        }
        timer += Time.deltaTime;
        if (timer <= zombieSpawnTime)
        {
            //spawnZombie();
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

    public void spawnZombie()
    {
        Zombie zombie = Instantiate(zombiePrefab);
        zombie.transform.position = new Vector3(-10, -1, 0);
    }

    void SpeedUp()
    {
        hotPrefab.GetComponent<BackgroundScroller>().speed.x -= speedIncrease ;
        coldPrefab.GetComponent<BackgroundScroller>().speed.x -= speedIncrease;
        defaultPrefab.GetComponent<BackgroundScroller>().speed.x -= speedIncrease;
    }

}
