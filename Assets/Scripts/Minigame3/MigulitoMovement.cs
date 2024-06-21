using UnityEngine;

public class MigulitoMovement : MonoBehaviour
{
    public float nSpeed = 0.5f; //Velocidad promedio
    public float goofyAhhSpeed = 2.0f; //Pos eso
    public float isAlerted = 0f;
    public float speed = 1.0f;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        //1.99
        //-0.75

        //-7.4
        //8.1

        //2
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            isAlerted = Random.Range(5f, 7f);
        }

        if(isAlerted > 0)
        {
            speed = goofyAhhSpeed * ManagingFunctions.BoolToInt(spriteRenderer.flipX);
            isAlerted -= Time.deltaTime;
        }
        else
        {
            speed = nSpeed * ManagingFunctions.BoolToInt(spriteRenderer.flipX);
        }

        if (transform.position.x > 2)
        {
            if(transform.position.y <= -0.67f)
            {
                transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, -0.67f);
            }
            else
            {
                transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y - 4 * Time.deltaTime);
            }
        }
        else
        {
            if (transform.position.y >= 2.05f)
            {
                transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, 2.05f);
            }
            else
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + 6 * Time.deltaTime);
            }
        }

        if (transform.position.x < -7.4f)
        {
            spriteRenderer.flipX = true;
        }
        if (transform.position.x > 8.1f)
        {
            spriteRenderer.flipX = false;
        }
    }
}
