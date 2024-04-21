using UnityEngine;
using System.Collections;

public class FireMover : MonoBehaviour
{
    // Coordenadas de inicio y fin
    public float startX = 10.27f;
    public float endX = -10f;

    // Tiempo mínimo y máximo de espera
    public float minWaitTime = 1.0f;
    public float maxWaitTime = 1.5f;

    // Duración del movimiento
    public float moveDuration = 2.0f;

    private IEnumerator Start()
    {
        while (true)
        {
            // Esperar un tiempo aleatorio
            float waitTime = Random.Range(minWaitTime, maxWaitTime);
            yield return new WaitForSeconds(waitTime);

            // Teletransportar a la posición inicial
            transform.position = new Vector3(startX, transform.position.y, transform.position.z);

            // Mover al punto final en el eje X
            float elapsedTime = 0;
            Vector3 startPos = transform.position;
            Vector3 endPos = new Vector3(endX, transform.position.y, transform.position.z);

            while (elapsedTime < moveDuration)
            {
                elapsedTime += Time.deltaTime;
                float t = Mathf.Clamp01(elapsedTime / moveDuration);
                transform.position = Vector3.Lerp(startPos, endPos, t);
                yield return null; // Esperar hasta el próximo frame
            }
        }
    }
}
