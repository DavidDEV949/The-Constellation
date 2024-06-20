using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class OttoM4 : MonoBehaviour
{
    public float jumpForce = 10f; // Fuerza del salto
    private Rigidbody2D rb;
    private bool isGrounded; // Indica si el jugador está tocando el suelo
    bool HasMuerto = false;
    private int puntuacion = 0;
    public Text puntuacionText;

    void PanConChocolate()
    {
        puntuacion++;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("PanConChocolate", 0.2f, 0.2f);
    }

    void Update()
    {
        puntuacionText.text = puntuacion.ToString();

        // Si se presiona la tecla espacio y el jugador está en el suelo, saltar
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    // Método para verificar si el jugador está tocando el suelo
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true; // El jugador está tocando el suelo
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false; // El jugador deja de tocar el suelo
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Peligro"))
        {
            Debug.Log("Te moristeeee M4");
            Muerto();
        }
    }

    void Muerto()
    {
        HasMuerto = true;
    }
}
