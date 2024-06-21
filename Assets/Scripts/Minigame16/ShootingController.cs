using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{

    [SerializeField] private Transform ShooterController;
    [SerializeField] private Rigidbody2D shipRb2D;
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
        GameObject bullet = Instantiate(Bullet, ShooterController.position, ShooterController.rotation);
        bullet.GetComponent<BulletController>().RecalculateVelocity(shipRb2D.velocity.x, 20f);
    }

}
