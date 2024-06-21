using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
{
    
    [SerializeField] private float verticalSpeed = 20;
    [SerializeField] private float horizontalSpeed = 0f;
    public Vector2 speed = Vector2.zero;

    public void RecalculateVelocity(float horizontalSpeed, float verticalSpeed)
    {
        speed = new Vector2(horizontalSpeed, verticalSpeed);
    }

    void Update()
    {
        transform.Translate(speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("M6_Collider"))
        {
            Destroy(gameObject);
        }

        if (collision.transform.CompareTag("Enemigo"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

}
