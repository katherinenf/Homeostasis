using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{

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

    }
}
