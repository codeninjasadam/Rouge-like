using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPGem : MonoBehaviour
{
    public int xpAmount = 10;
    public float moveSpeed = 5f;       // how fast gem flies toward player
    private Transform targetPlayer;    // store player reference
    private bool attracted = false;    // whether gem is flying toward player

    void Update()
    {
        if (attracted && targetPlayer != null)
        {
            // Move gem toward player
            transform.position = Vector2.MoveTowards(
                transform.position,
                targetPlayer.position,
                moveSpeed * Time.deltaTime
            );
        }
    }

    public void Attract(Transform player)
    {
        targetPlayer = player;
        attracted = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerExperience xp = other.GetComponent<PlayerExperience>();
            if (xp != null)
            {
                xp.GainXP(xpAmount);
            }
            Destroy(gameObject);
        }
    }
}
