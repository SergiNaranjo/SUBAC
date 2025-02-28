using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoPulpo : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab de la bala
    public Transform firePoint; // Punto de origen de los disparos
    public float bulletSpeed = 5f; // Velocidad de las balas
    public float bulletSpacing = 0.5f; // Separación entre las balas
    public float fireRate = 2f; // Tiempo entre cada disparo

    private float nextFireTime;

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {
        // Crear tres balas alineadas
        for (int i = -1; i <= 1; i++)
        {
            Vector3 spawnPosition = firePoint.position + new Vector3(i * bulletSpacing, 0, 0);
            GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
            bullet.tag = "BalaEnemigo"; // Asigna el tag a la bala

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.right * bulletSpeed; // Dispara hacia la derecha
            }
        }
    }
}
