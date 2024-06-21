using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
{
    
    [SerializeField] private float BulletSpeed = 20;
    //[SerializeField] private float BulletDamage = 1.25f;

    void Update()
    {

        transform.Translate(Vector2.up * BulletSpeed * Time.deltaTime);

    }

    private void OnCollissionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("M6_Collider"))
        {
            Destroy(gameObject);
        }
    }

}
