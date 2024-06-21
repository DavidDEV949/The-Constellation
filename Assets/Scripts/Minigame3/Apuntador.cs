using UnityEngine;

public class Apuntador : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    void Update()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spriteRenderer.enabled = MovimientoTomate.throwState == 0;
    }
}