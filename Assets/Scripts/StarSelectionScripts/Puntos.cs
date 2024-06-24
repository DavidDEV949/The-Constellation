using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntos : MonoBehaviour
{
    private int monedas;
    public Text monedasText;

    void Start()
    {
        monedas = 0;
    }

    void Update()
    {
        monedasText.text = monedas.ToString();
    }
}
