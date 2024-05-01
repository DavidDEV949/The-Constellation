using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour {


	void Start ()
    {
        GetComponent<SpriteRenderer>().color = Color.HSVToRGB(Random.Range(0.1f, 0.2f), 1f, 1f);
	}


    void Update()
    {
        transform.position += Vector3.left * 10 * Time.deltaTime;

        Color color = GetComponent<SpriteRenderer>().color;
        color.a -= 5f * Time.deltaTime;
        GetComponent<SpriteRenderer>().color = color;
        if (color.a < 0f)
        {
            Destroy(gameObject);
        }
    }
}
