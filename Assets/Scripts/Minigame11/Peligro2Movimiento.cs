using UnityEngine;

public class Peligro2Movimiento : MonoBehaviour
{
    // Referencia al objeto Peligro
    public Transform peligro;

    // Offset en el eje Y
    public float offsetY = 17.0f;

    void Update()
    {
        // Verificar que el objeto peligro esté asignado
        if (peligro != null)
        {
            // Obtener la posición del objeto peligro y sumar el offset en Y
            Vector3 nuevaPosicion = new Vector3(peligro.position.x, peligro.position.y + offsetY, peligro.position.z);

            // Mover el objeto a la nueva posición
            transform.position = nuevaPosicion;
        }
    }
}
