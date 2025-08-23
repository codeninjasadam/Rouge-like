using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitingWeapon : MonoBehaviour
{
    public Transform player;       // assign the player in inspector
    public float orbitRadius = 2f; // how far from player
    public float orbitSpeed = 180f; // degrees per second
    public int damage = 10;

    private float angle; // keeps track of rotation

    void Update()
    {
        if (player == null) return;

        // increase angle
        angle += orbitSpeed * Time.deltaTime;
        if (angle > 360f) angle -= 360f;

        // calculate position around player
        float rad = angle * Mathf.Deg2Rad;
        Vector2 offset = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)) * orbitRadius;

        transform.position = player.position + (Vector3)offset;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemy = other.GetComponent<EnemyHealth>();
            if (enemy != null)
                enemy.TakeDamage(damage);
        }
    }
}
