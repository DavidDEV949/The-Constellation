using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{

    [SerializeField] private Transform ShooterController;
    [SerializeField] private GameObject Bullet;

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

    }

    void Shoot()
    {
        Instantiate(Bullet, ShooterController.position, ShooterController.rotation);
    }

}
