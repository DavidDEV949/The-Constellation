using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{

    public float SpeedX = 1f;

    void Update()
    {
        transform.Translate(new Vector2(-SpeedX * Time.deltaTime, 0));

        if(transform.position.x < -17.91f)
        {
            transform.Translate(new Vector2(35.82f, 0));
        }
    }

}

