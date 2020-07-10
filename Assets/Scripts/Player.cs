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
    public int health;
    public Rigidbody2D rb;
    public Vector2 jumpHeight;

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(jumpHeight, ForceMode2D.Impulse);
        }

    }

   
    private void OnTriggerEnter2D(Collider2D collider)
    {
        GM.stimulus = spawner.currentType;
    }



}
