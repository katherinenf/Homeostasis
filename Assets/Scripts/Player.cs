using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite jumpSprite;
    public BackgroundSpawner spawner;
    public GameManager GM;
    public float timer;
    public float delayAmount;
    public int health;
    public Rigidbody2D rb;
    public Vector2 jumpHeight;
    float velocityY;
    public float jumpImpulse;
    public float gravity;
    public float floorY;

    // Start is called before the first frame update
    void Start()
    {
        floorY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Sprite currentSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        if (transform.position.y != floorY)
        {
            currentSprite = jumpSprite;
            gameObject.GetComponent<SpriteRenderer>().sprite = currentSprite;
        }
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
        if (Input.GetKeyDown(KeyCode.Space) && transform.position.y == floorY)
        {
            velocityY = jumpImpulse;
        }
        velocityY += (gravity * Time.deltaTime);
        transform.position += new Vector3(0, velocityY * Time.deltaTime, 0);
        if(transform.position.y <= floorY)
        {
            velocityY = 0;
            transform.position = new Vector2(transform.position.x, floorY);
        }   

    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<BackgroundScroller>())
        {
            GM.stimulus = spawner.currentType;
            GM.response = null;
        }
        if (collider.gameObject.GetComponent<Zombie>())
        {
            if(GM.health > 0)
            {
                GM.health -= 10;
                velocityY = jumpImpulse;
            }

        }
    }

}
