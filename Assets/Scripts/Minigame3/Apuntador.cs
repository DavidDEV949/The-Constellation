using UnityEngine;

public class Apuntador : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento del jugador

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Captura la entrada del teclado
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calcula el vector de movimiento
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        // Aplica el movimiento al Rigidbody del jugador
        rb.velocity = movement * speed;
    }
}