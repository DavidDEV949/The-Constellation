using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M16_PlayerController : MonoBehaviour
{

    private Rigidbody2D rb2d;
    [SerializeField] private float SpeedX;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        SpeedX = 10.5f;
    }
    
    void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb2d.velocity = new Vector2(-SpeedX, rb2d.velocity.y);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb2d.velocity = new Vector2(SpeedX, rb2d.velocity.y);
        }
    }

}
