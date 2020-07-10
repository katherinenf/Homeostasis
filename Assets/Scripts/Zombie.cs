using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public Sprite sprite1;
    public Sprite sprite2;
    public float timer;
    public float delayAmount;
    public Vector2 speed;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the amount to move this frame
        Vector2 delteMove = speed * Time.fixedDeltaTime;

        // Update rigidbody position
        rb.MovePosition(rb.position + delteMove);

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

}
