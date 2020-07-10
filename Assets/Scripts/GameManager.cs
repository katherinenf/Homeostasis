using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public string stimulus;
    public string response;
    public float health;
    public float timer;
    public float distance;
    public Text distanceText;
    public float delayAmount;
    public string currentType;
    public Text stimulusText;
    public Text healthText;
    public int healthLossPerSecond;
    public Player player;
    public Zombie zombiePrefab;
    

    // Start is called before the first frame update
    void Start()
    {
        //spawnZombie();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = ((int)health).ToString();
        //as long as health is greater than zero(the game hasn't ended)
        if (health > 0)
        {
            //keeps track of "distance", needs to be updated if we decide on a varient that speeds up
            timer += Time.deltaTime;

            if (timer >= delayAmount)
            {
                timer = 0f;
                distance++;
                distanceText.text = distance.ToString();
                response = null;
            }
            //checks if stimulus matches response and decrements health if not
            if (stimulus != response && stimulus != "default")
            {
                health -= Time.deltaTime * healthLossPerSecond;
            }

            if(stimulus == response)
            {
                player.GetComponent<SpriteRenderer>().color = Color.white;
                stimulusText.text = null;
            }
            playerUpdate();

        }
    }

    public void playerUpdate()
    {
        SpriteRenderer sr = player.GetComponent<SpriteRenderer>();

        if (stimulus == "hot" && response != "hot")
        {
            stimulusText.text = "Oh no! You're overheating!";
            sr.color = Color.red;
        }
        if (stimulus == "cold" && response != "cold")
        {
            stimulusText.text = "Oh no! You're getting too cold!";
            sr.color = Color.green;
        }
        if (stimulus == "sick" && response != "sick")
        {
            stimulusText.text = "Oh no! You're not feeling so good!";
            sr.color = Color.cyan;
        }
        if(stimulus == "default")
        {
            player.GetComponent<SpriteRenderer>().color = Color.white;
            stimulusText.text = null;
        }
    }

    public void HotCLick()
    {
        response = "hot";
    }

    public void ColdCLick()
    {
        response = "cold";
    }

    public void SickClick()
    {
        response = "sick";
    }
    public void HeartClick()
    {
        stimulus = "hot";
    }

    public void spawnZombie()
    {
        Zombie zombie = Instantiate(zombiePrefab);
        zombie.transform.position = new Vector3(-10, -1, 0);
    }
}
