using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLunch : MonoBehaviour
{
    [Header("Projectile Settings")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private bool autoFire = false;

    private float nextFireTime = 0f;

    void Update()
    {
        if (autoFire)
        {
            if (Time.time > nextFireTime)
            {
                FireProjectile();
                nextFireTime = Time.time + fireRate;
            }
        }
        else
        {
            // Manual fire with left mouse button
            if (Input.GetMouseButtonDown(0) && Time.time > nextFireTime)
            {
                FireProjectile();
                nextFireTime = Time.time + fireRate;
            }
        }
    }

    public void FireProjectile()
    {
        // Create the projectile at the fire point position and rotation
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        // Get the rigidbody component (if any) and apply force
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = firePoint.forward * projectileSpeed;
        }
        else
        {
            // If no rigidbody, check for Rigidbody2D (for 2D games)
            Rigidbody2D rb2d = projectile.GetComponent<Rigidbody2D>();
            if (rb2d != null)
            {
                rb2d.velocity = firePoint.right * projectileSpeed; // In 2D, right is forward
            }
        }

        // If neither Rigidbody nor Rigidbody2D, try to get a ProjectileMovement script
        //if (rb == null && projectile.GetComponent<Rigidbody2D>() == null)
        //{
        //    /*ProjectileMovement projectileMovement = projectile.GetComponent<ProjectileMovement>();
        //    if (projectileMovement != null)
        //    {
        //        projectileMovement.Launch(firePoint.forward, projectileSpeed);
        //    }*/
        //}
    }
}
