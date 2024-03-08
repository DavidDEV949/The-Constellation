using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{

    Transform tr;
    float SpeedX;

    void Start()
    {
        tr = GetComponent<Transform>();
        SpeedX = 1f;
    }

    void Update()
    {
        tr.Translate(-SpeedX * Time.deltaTime, 0, 0);
    }

}
