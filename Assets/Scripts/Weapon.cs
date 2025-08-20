using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; // for easy sorting

public class Weapon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float fireRate = 1f; // Shoot every X seconds
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= fireRate)
        {
            Shoot();
            timer = 0f;
        }

    }

    void Shoot()
    {
        if (projectilePrefab == null) return;

        // Find all enemies in the scene
        Enemy[] enemies = FindObjectsOfType<Enemy>();

        if (enemies.Length == 0)
        {
            // No enemies, just shoot to the right
            SpawnBullet(Vector2.right);
            return;
        }

        // Pick the closest enemy
        Transform closest = enemies
            .OrderBy(e => Vector2.Distance(transform.position, e.transform.position))
            .First().transform;

        // Aim toward it
        Vector2 direction = (closest.position - transform.position).normalized;

        SpawnBullet(direction);
    }

    void SpawnBullet(Vector2 direction)
    {
        GameObject bullet = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Projectile>().SetDirection(direction);
    }
}
