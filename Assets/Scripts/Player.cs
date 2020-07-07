using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Sprite sprite1;
    public Sprite sprite2;
    public BackgroundSpawner spawner;
    public GameManager GM;
    public float timer;
    public float delayAmount;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Sprite currentSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        timer += Time.deltaTime;
        if (timer >= delayAmount)
        {
            timer = 0f;
            if (currentSprite == sprite1)
            {
                currentSprite = sprite2;
            }
            else
            {
                currentSprite = sprite1;
            }
            gameObject.GetComponent<SpriteRenderer>().sprite = currentSprite;
        }
    }

   
    private void OnTriggerEnter2D(Collider2D collider)
    {
        GM.stimulus = spawner.currentType;
        //GM.stimulusText.text = spawner.currentType;
        ChangeColor(spawner.currentType);
    }

    // set the color of the player sprite based on the stimulus
    private void ChangeColor(string type)
    {
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();

        if (type == "hot")
        {
            sr.color = Color.red;
            GM.stimulusText.text = "Oh no! You're overheating!";
        }
        if (type == "default")
        {
            sr.color = Color.white;
            GM.stimulusText.text = null;

        }
        if ( type == "sick")
        {
            sr.color = Color.green;
            GM.stimulusText.text = "Oh no! You're not feeling so good!";
        }
        else if (type == "cold")
        {
            sr.color = Color.cyan;
            GM.stimulusText.text = "Oh no! You're getting too cold!";

        }
    }

}
