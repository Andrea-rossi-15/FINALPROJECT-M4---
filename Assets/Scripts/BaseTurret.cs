using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTurret : TurretControl
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;

    protected override void Fire()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }

}
