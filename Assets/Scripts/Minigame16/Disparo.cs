using UnityEngine;
using System.Collections;

public class Disparo : MonoBehaviour
{
    public GameObject jugador;
    public float velocidadMovimiento = 5.0f;
    private bool disparoActivado = false;
    private Vector3 posicionInicial;

    void Start()
    {
        // Guarda la posición inicial del objeto disparo
        posicionInicial = transform.position;
    }

    void Update()
    {
        // Si se presiona la tecla Espacio y el disparo no está activado
        if (Input.GetKeyDown(KeyCode.Space) && !disparoActivado)
        {
            // Activa el disparo y lo mueve hacia la posición del jugador
            disparoActivado = true;
            gameObject.SetActive(true);
            MoveToPlayer();
        }

        // Si el disparo está activado
        if (disparoActivado)
        {
            // Mueve el disparo hacia arriba hasta Y=5.6
            transform.Translate(Vector3.up * velocidadMovimiento * Time.deltaTime);

            // Si el disparo ha alcanzado la posición Y=5.6
            if (transform.position.y >= 5.6f)
            {
                // Reinicia la posición del disparo
                transform.position = posicionInicial;
            }
        }
    }

    void MoveToPlayer()
    {
        // Calcula la posición final del disparo con respecto al jugador
        Vector3 posicionFinal = jugador.transform.position;
        posicionFinal.y += 1.29f;
        posicionFinal.x -= 0.07f;

        // Mueve el disparo hacia la posición final en 1.5 segundos
        transform.position = Vector3.MoveTowards(transform.position, posicionFinal, velocidadMovimiento * Time.deltaTime * 1.5f);
    }
}
