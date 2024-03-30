using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float coyoteTime = 0.2f; // Nuevo: Tiempo de coyote en segundos
    private float coyoteCounter = 0f; // Nuevo: Contador de tiempo de coyote

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimiento horizontal
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Nuevo: Actualizar el contador de coyote time
        if (isGrounded)
        {
            coyoteCounter = coyoteTime;
        }
        else
        {
            coyoteCounter -= Time.deltaTime; // Arreglado: Utilizando Time.deltaTime
        }

        // Salto (incluyendo coyote time)
        if ((Input.GetButtonDown("Jump") && isGrounded) || (Input.GetButtonDown("Jump") && coyoteCounter > 0f)) // Arreglado: Agregando condición de estar en el suelo
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            coyoteCounter = 0f; // Nuevo: Restablecer el contador de coyote time después del salto
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        // Verificar si el jugador está en el suelo y el objeto es etiquetado como "Ground"
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (Vector2.Dot(contact.normal, Vector2.up) > 0.5f && collision.collider.CompareTag("Ground"))
            {
                isGrounded = true;
                return;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Verificar si el jugador deja de tocar el suelo
        isGrounded = false;
    }
}
