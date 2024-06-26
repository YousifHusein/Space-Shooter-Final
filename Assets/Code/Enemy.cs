using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float expValue = 10f;
    public float health = 100f;
    public float damageAmount = 50f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();

                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damageAmount);
                }
            }
            Destroy(gameObject);
        }
    }
}
