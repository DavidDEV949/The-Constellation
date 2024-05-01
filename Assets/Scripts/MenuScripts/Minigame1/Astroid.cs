using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : MonoBehaviour {

    Player player;
    public GameObject particle;

	void Start ()
    {
        StartCoroutine(B());
        player = GameObject.Find("Otto_cohete").GetComponent<Player>();	
	}
	
	void Update ()
    {
        transform.eulerAngles += Vector3.forward * -180 * Time.deltaTime;
        transform.position += Vector3.left * 15 * Time.deltaTime;
        if(transform.position.x < -15f)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator B()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            for (int i = 0; i < 3; i++)
            {
                Instantiate(particle, new Vector2(transform.position.x + Random.Range(-0.4f, 0.4f), transform.position.y + Random.Range(-0.4f, 0.4f)), Quaternion.identity);
            }
        }
    }
}
