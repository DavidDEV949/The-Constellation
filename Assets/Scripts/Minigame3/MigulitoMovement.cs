using UnityEngine;

public class MigulitoMovement : MonoBehaviour
{
    public Transform migulitoTransform;
    public float speed = 1.0f;
    private Vector2 targetPosition;
    private bool moving = false;

    void Start()
    {
        // Configurar la posición inicial de Migulito
        migulitoTransform.position = new Vector2(9.87f, -0.87f);
        // Establecer la posición de destino
        targetPosition = new Vector2(2.37f, migulitoTransform.position.y);
        // Comenzar el movimiento
        MoveToTarget(targetPosition, 0.8f);
    }

    void Update()
    {
        if (moving)
        {
            // Mover Migulito hacia la posición de destino
            migulitoTransform.position = Vector2.MoveTowards(migulitoTransform.position, targetPosition, speed * Time.deltaTime);

            // Comprobar si hemos alcanzado la posición de destino
            if (Vector2.Distance(migulitoTransform.position, targetPosition) < 0.01f)
            {
                // Si hemos llegado, detener el movimiento
                moving = false;

                // Comprobar la posición actual para determinar el siguiente movimiento
                if (targetPosition.x == 2.37f)
                {
                    // Subir hacia la siguiente posición
                    targetPosition = new Vector2(1.27f, 1.84f);
                    MoveToTarget(targetPosition, 0.5f);
                }
                else if (targetPosition.x == 1.27f && targetPosition.y == 1.84f)
                {
                    // Avanzar hacia la última posición
                    targetPosition = new Vector2(-9.8f, 1.84f);
                    MoveToTarget(targetPosition, 0.8f);
                }
                else if (targetPosition.x == -9.8f)
                {
                    // Ocultar Migulito
                    migulitoTransform.gameObject.SetActive(false);
                }
            }
        }
    }

    void MoveToTarget(Vector2 target, float time)
    {
        // Configurar la posición de destino y activar el movimiento
        targetPosition = target;
        moving = true;
        // Calcular la velocidad de movimiento
        speed = Vector2.Distance(migulitoTransform.position, targetPosition) / time;
    }
}
