using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject astroid;
    public GameObject particle;
    public Rigidbody2D rb2D;
    public float yV = 0f;
    public float acceleration = 10f;
    public float maxGravity = 10f;
    public float timer = 0f;

    public bool coinOneUnlocked = false;
    public bool coinTwoUnlocked = false;
    public bool coinThreeUnlocked = false;

    void Start ()
    {
        StartCoroutine(AsteroidLoop());
        rb2D = GetComponent<Rigidbody2D>();
    }
	

	void Update ()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            yV += acceleration * Time.deltaTime;
        }
        else
        {
            yV -= acceleration * Time.deltaTime;
        }

        yV = Mathf.Clamp(yV, -maxGravity, maxGravity);

        transform.eulerAngles = Vector3.forward * ((yV / maxGravity) * 40);
        rb2D.velocity = new Vector2(0, yV);
        timer += Time.deltaTime;

        if(timer > 15f)
        {
          if(coinOneUnlocked)
          {
if(timer > 25f)
        {
          if(coinTwoUnlocked)
          {
            if(timer > 35f)
        {
          if(coinThreeUnlocked)
          {

          }
          else 
          {
 
          }
        }
          }
          else 
          {
 
          }
        }
          }
          else 
          {
 
          }
        }
    }

    IEnumerator AsteroidLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0.2f, 0.5f));
            GameObject ins = Instantiate(astroid, new Vector2(20, Random.Range(4f, -4f)), Quaternion.identity);
        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        yV = yV * 0.5f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        yV = yV * 0.5f;

        if (collision.gameObject.CompareTag("Aste"))
        {
            for (int i = 0; i < 75; i++)
            {
                Instantiate(particle, new Vector2(transform.position.x + Random.Range(-2f, 2f), transform.position.y + Random.Range(-2f, 2f)), Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }
}
