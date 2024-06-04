using UnityEngine;

public class Jugador : MonoBehaviour
{
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool isGrounded;
    bool muerto = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameObject.SetActive(true);
    }

    void Update()
    {
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

    void Te_acabas_de_hacer_la_muricion()
    {
        muerto = true;
    }
}
