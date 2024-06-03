using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisiónPeligro : MonoBehaviour
{
    // Este método se llama cuando el objeto comienza a colisionar con otro objeto
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si el objeto con el que se ha colisionado tiene la etiqueta "Peligro"
        if (collision.gameObject.CompareTag("Peligro"))
        {
            // Aquí puedes poner el código que se debe ejecutar al detectar la colisión con el objeto peligroso
            Debug.Log("¡Colisión con objeto peligroso detectada!");
        }
    }
}
