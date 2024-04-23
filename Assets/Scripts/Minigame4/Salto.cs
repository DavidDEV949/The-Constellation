using UnityEngine;

public class Salto : MonoBehaviour
{
    public float jumpForce = 10f; // Fuerza del salto
    private Rigidbody2D rb;
    private bool isGrounded; // Indica si el jugador está tocando el suelo

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
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
}
