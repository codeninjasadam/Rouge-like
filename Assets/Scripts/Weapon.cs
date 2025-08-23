using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float fireRate = 1f;
    public float projectileSpeed = 5f;
    public int damage = 10;
    private float fireCooldown;

    public void HandleWeapon()
    {
        fireCooldown -= Time.unscaledDeltaTime;
        if (fireCooldown <= 0f)
        {
            Shoot();
            fireCooldown = 1f / fireRate;
        }
    }

void Shoot()
{
    GameObject bullet = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
    Projectile proj = bullet.GetComponent<Projectile>();

    if (rb != null)
    {
        // Find all enemies
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        if (enemies.Length > 0)
        {
            // Get closest enemy
            Enemy closest = enemies[0];
            float minDist = Vector2.Distance(transform.position, closest.transform.position);

            foreach (Enemy e in enemies)
            {
                float dist = Vector2.Distance(transform.position, e.transform.position);
                if (dist < minDist)
                {
                    closest = e;
                    minDist = dist;
                }
            }

            // Calculate direction
            Vector2 dir = (closest.transform.position - transform.position).normalized;
            rb.velocity = dir * proj.speed;
        }
        else
        {
            // No enemies: shoot forward
            rb.velocity = transform.right * proj.speed;
        }
    }

    if (proj != null)
        proj.damage = damage;
}

    // Leveling up weapon
    public void UpgradeWeapon()
    {
        damage += 5;
        fireRate += 0.2f;
    }
}
