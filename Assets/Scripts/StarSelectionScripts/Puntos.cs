using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntos : MonoBehaviour
{
    private int puntuacion;
    public Text puntuacionText;

    void Start()
    {
        puntuacion = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            puntuacion++;
        }

        puntuacionText.text = puntuacion.ToString();
    }
}
