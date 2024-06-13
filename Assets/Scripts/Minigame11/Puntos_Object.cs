using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntos_Object : MonoBehaviour
{
    public Transform peligro;

    void Update()
    {
        if (peligro != null)
        {
            Vector3 nuevaPosicion = new Vector3(peligro.position.x, peligro.position.y, peligro.position.z);
            transform.position = nuevaPosicion;
        }
    }
}
