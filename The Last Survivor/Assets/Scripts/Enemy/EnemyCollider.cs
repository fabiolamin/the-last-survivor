using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    Health enemyHealth;

    private void Awake()
    {
        enemyHealth = GetComponent<Health>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            enemyHealth.ChangeHealth(-10);
            if(enemyHealth.HealthValue <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
