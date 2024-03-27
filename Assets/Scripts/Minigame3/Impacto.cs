using UnityEngine;

public class Impacto : MonoBehaviour
{
    public GameObject impactoPrefab; // Prefab del objeto Impacto

    private Vector3 posicionTomate; // Variable para almacenar la posición del Tomate

    private void OnEnable()
    {
        // Suscribirse al evento de impacto del Tomate
        MovimientoTomate.OnImpacto += CrearClonImpacto;
    }

    private void OnDisable()
    {
        // Desuscribirse del evento de impacto del Tomate
        MovimientoTomate.OnImpacto -= CrearClonImpacto;
    }

    // Función que se activa cuando ocurre el impacto del Tomate
    private void CrearClonImpacto()
    {
        // Obtener la posición actual del Tomate
        posicionTomate = GameObject.FindWithTag("Tomate").transform.position;

        // Crear un clon del objeto Impacto en la posición del Tomate
        GameObject clonImpacto = Instantiate(impactoPrefab, posicionTomate, Quaternion.identity);

        // Destruir el clon después de 3 segundos
        Destroy(clonImpacto, 3f);
    }
}
