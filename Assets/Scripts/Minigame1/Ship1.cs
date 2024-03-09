using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship1 : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float gravity = 25f;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        transform.eulerAngles = new Vector3(0, 0, 4.5f * rb2d.velocity.y);
        if (Input.GetKey(KeyCode.Space))
        {
            rb2d.velocity += new Vector2(0, gravity * Time.deltaTime);
        }
        else
        {
            rb2d.velocity -= new Vector2(0, gravity * Time.deltaTime);
        }
        rb2d.velocity = new Vector2(rb2d.velocity.x, Mathf.Clamp(rb2d.velocity.y, -gravity / 2, gravity));
        transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = !transform.GetChild(0).GetComponent<SpriteRenderer>().flipX;
    }
}
