using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisiónPeligro : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(true);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Peligro"))
        {
            Debug.Log("¡Has muerto! (Minigame11:Peligro)");
            Te_acabas_de_hacer_la_muricion();
        }
    }

    void Te_acabas_de_hacer_la_muricion()
    {
        gameObject.SetActive(false);
    }
}
