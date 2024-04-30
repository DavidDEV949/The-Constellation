using UnityEngine;

public class M15 : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento
    public float jumpForce = 10f; // Fuerza de salto
    private Rigidbody2D rb; // Referencia al Rigidbody2D
    private bool isGrounded = false; // Bandera para comprobar si está en el suelo
    public float escalaDerecha = 0.12f; // Escala al moverse a la derecha
    public float escalaIzquierda = -0.12f; // Escala al moverse a la izquierda

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");

        // Establece la velocidad horizontal del Rigidbody2D
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        // Ajusta la escala en el eje X dependiendo de la dirección de movimiento
        if (move > 0)
        {
            transform.localScale = new Vector3(escalaDerecha, transform.localScale.y, transform.localScale.z);
        }
        else if (move < 0)
        {
            transform.localScale = new Vector3(escalaIzquierda, transform.localScale.y, transform.localScale.z);
        }

        // Salto con espacio solo si está en el suelo
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isGrounded = false; // El personaje ha saltado
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true; // El personaje está en el suelo
        }
    }
}
