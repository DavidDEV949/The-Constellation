using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M16_Spawner : MonoBehaviour
{
    public GameObject enemy16;
    public Transform enemyContainer;

    void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            GameObject newEnemy = Instantiate(enemy16, enemyContainer);
            newEnemy.transform.position = new Vector2(8f - (2.1f * i), 3);
        }

        for (int i = 0; i < 8; i++)
        {
            GameObject newEnemy = Instantiate(enemy16, enemyContainer);
            newEnemy.transform.position = new Vector2(8f - (2.1f * i), 1);
        }
    }
}
