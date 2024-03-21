using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target; // Transform del jugador (Otto)
    public Vector3 offset = new Vector3(0f, 0f, -10f); // Desplazamiento de la cámara desde el jugador

    void LateUpdate()
    {
        if (target != null)
        {
            // Actualizar la posición de la cámara para que siga al jugador con un desplazamiento (offset)
            transform.position = target.position + offset;
        }
    }
}