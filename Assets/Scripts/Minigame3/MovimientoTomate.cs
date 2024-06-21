using UnityEngine;
using System.Collections;

public class MovimientoTomate : MonoBehaviour
{
    public Transform apuntador;
    public SpriteRenderer spriteRenderer;
    public Sprite average;
    public Sprite squish;
    public Vector3 target;
    public Vector3 startPos;
    public static int throwState = 0;
    public float parabolaState = 0f;
    public float awaitTime = 0f;
    public float smashTime = 0f;

    //0 no lanzado
    //1 lanzando
    //2 esperando colision
    //3 colision
    //4 no colision (caicion)


    private void Update()
    {
        if (throwState == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                target = apuntador.transform.position;

                startPos = transform.position;
                throwState = 1;
                parabolaState = 0f;
            }
        }
        else if (throwState == 1)
        {
            parabolaState += Time.deltaTime * 2;
            parabolaState = Mathf.Clamp01(parabolaState);

            transform.position = Vector3.Lerp(startPos, target, parabolaState);
            transform.localScale = Vector2.one * ((1 - parabolaState) * 0.4f + 0.3f);

            if(parabolaState == 1f)
            {
                throwState = 2;
                awaitTime = 0.1f;
            }
        }
        else if (throwState == 2)
        {
            if(awaitTime > 0f)
            {
                awaitTime -= Time.deltaTime;
            }
            else
            {
                throwState = 4;
            }
        }
        else if (throwState == 3)
        {
            spriteRenderer.sprite = squish;

            if(smashTime < 0)
            {
                transform.position = startPos;
                transform.localScale = Vector2.one * 0.7f;
                throwState = 0;
            }
            else
            {
                smashTime -= Time.deltaTime;
            }
        }
        else if (throwState == 4)
        {
            transform.Translate(Vector2.down * Time.deltaTime * 8);
            if(transform.position.y < -9f)
            {
                transform.position = startPos;
                transform.localScale = Vector2.one * 0.7f;
                throwState = 0;
            }
        }

        if (throwState != 3)
        {
            spriteRenderer.sprite = average; //tomate
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (throwState == 2)
        {
            if (collider.CompareTag("Player"))
            {
                Destroy(collider.gameObject); //sustituye esto por el codigo de muerte.
                throwState = 3;
                smashTime = 5f;
            }
            else if(collider.CompareTag("Ground"))
            {
                throwState = 3;
                smashTime = 1f;
            }
        }
    }
}
