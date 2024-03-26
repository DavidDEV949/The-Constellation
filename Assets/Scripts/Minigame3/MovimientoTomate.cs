using UnityEngine;
using System.Collections;

public class MovimientoTomate : MonoBehaviour
{
    public Transform apuntador; // Referencia al objeto Apuntador
    public float tiempoDeMovimiento = 0.5f; // Tiempo en segundos para el movimiento
    public float reduccionDeTamaño = 0.5f; // Porcentaje de reducción de tamaño (0.5 = 50%)
    public float tiempoDeEsperaEntreLanzamientos = 0.8f; // Tiempo de espera entre lanzamientos

    private Vector3 posicionInicial; // Posición inicial del Tomate
    private Vector3 posicionFinal; // Posición final del Tomate
    private float tiempoTranscurrido = 0f; // Tiempo transcurrido desde el inicio del movimiento

    private void Start()
    {
        // Guardar la posición inicial del Tomate
        posicionInicial = transform.position;
    }

    private void Update()
    {
        // Si se presiona la tecla espacio y el movimiento no ha comenzado y ha pasado el tiempo de espera
        if (Input.GetKeyDown(KeyCode.Space) && tiempoTranscurrido == 0f)
        {
            // Guardar la posición final del Tomate como la posición actual del Apuntador
            posicionFinal = apuntador.position;

            // Comenzar el movimiento
            StartCoroutine(MoverTomate());
        }
    }

    private IEnumerator MoverTomate()
    {
        // Repetir hasta que el tiempo transcurrido sea igual al tiempo de movimiento
        while (tiempoTranscurrido < tiempoDeMovimiento)
        {
            // Incrementar el tiempo transcurrido
            tiempoTranscurrido += Time.deltaTime;

            // Calcular la posición intermedia utilizando Lerp
            Vector3 nuevaPosicion = Vector3.Lerp(posicionInicial, posicionFinal, tiempoTranscurrido / tiempoDeMovimiento);

            // Calcular la escala intermedia
            float nuevaEscala = Mathf.Lerp(1f, reduccionDeTamaño, tiempoTranscurrido / tiempoDeMovimiento);

            // Establecer la posición y la escala del Tomate
            transform.position = nuevaPosicion;
            transform.localScale = new Vector3(nuevaEscala, nuevaEscala, 1);

            // Esperar un frame
            yield return null;
        }

        // Asegurarse de que el Tomate esté en la posición final y con el tamaño adecuado
        transform.position = posicionFinal;
        transform.localScale = new Vector3(reduccionDeTamaño, reduccionDeTamaño, 1);

        // Reiniciar el tiempo transcurrido para futuros movimientos
        tiempoTranscurrido = 0f;

        // Esperar un tiempo antes de permitir otro lanzamiento
        yield return new WaitForSeconds(tiempoDeEsperaEntreLanzamientos);
    }
}
