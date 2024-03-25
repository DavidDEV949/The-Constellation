using UnityEngine;
using System.Collections;

public class MovimientoTomate : MonoBehaviour
{
    public Transform apuntador;
    public float tiempoDeMovimiento = 0.5f;
    public float reduccionDeTamaño = 0.5f;

    private Vector3 posicionInicial;
    private Vector3 posicionFinal;
    private float tiempoTranscurrido = 0f;
    private bool disparoActivo = false;

    private void Start()
    {
        posicionInicial = transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.SetActive(true);

            // Reiniciar propiedades del Tomate antes de moverlo
            ReiniciarTomate();

            // Configurar destino y comenzar movimiento
            posicionFinal = apuntador.position;
            StartCoroutine(MoverTomate());
        }
    }

    private void ReiniciarTomate()
    {
        // Reiniciar posición y escala del Tomate
        transform.position = posicionInicial;
        transform.localScale = Vector3.one;

        // Detener cualquier movimiento anterior
        tiempoTranscurrido = 0f;
        disparoActivo = false;

        // Reactivar el objeto Tomate
        gameObject.SetActive(true);
    }

    private IEnumerator MoverTomate()
    {
        disparoActivo = true;

        while (tiempoTranscurrido < tiempoDeMovimiento)
        {
            tiempoTranscurrido += Time.deltaTime;
            Vector3 nuevaPosicion = Vector3.Lerp(posicionInicial, posicionFinal, tiempoTranscurrido / tiempoDeMovimiento);
            float nuevaEscala = Mathf.Lerp(1f, reduccionDeTamaño, tiempoTranscurrido / tiempoDeMovimiento);
            transform.position = nuevaPosicion;
            transform.localScale = new Vector3(nuevaEscala, nuevaEscala, 1);
            yield return null;
        }

        transform.position = posicionFinal;
        transform.localScale = new Vector3(reduccionDeTamaño, reduccionDeTamaño, 1);

        // Desactivar el objeto Tomate al completar el movimiento
        disparoActivo = false;
    }
}
