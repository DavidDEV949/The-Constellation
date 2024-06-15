using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jugador : MonoBehaviour
{
    private int puntos;
    public Text puntosText;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool isGrounded;
    bool muerto = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameObject.SetActive(true);
        puntos = 0;
    }

    void Update()
    {
        puntosText.text = puntos.ToString();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (muerto == false)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Peligro"))
        {
            Debug.Log("¡Has muerto! (Minigame11:Peligro)");
            Te_acabas_de_hacer_la_muricion();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Punto"))
        {
            puntos++;
        }
    }

    void Te_acabas_de_hacer_la_muricion()
    {
        muerto = true;
    }
}
