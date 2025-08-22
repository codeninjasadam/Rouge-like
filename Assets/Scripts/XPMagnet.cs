using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPMagnet : MonoBehaviour
{
    public float magnetRadius = 5f; // how far away gems get pulled

    void Update()
    {
        // Find all XP Gems in scene
        Collider2D[] gems = Physics2D.OverlapCircleAll(transform.position, magnetRadius);

        foreach (Collider2D gemCollider in gems)
        {
            XPGem gem = gemCollider.GetComponent<XPGem>();
            if (gem != null)
            {
                gem.Attract(transform); // tell gem to fly toward player
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // Show pickup radius in editor
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, magnetRadius);
    }
}
