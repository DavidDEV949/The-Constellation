using UnityEngine;

public class SaltoM11 : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
