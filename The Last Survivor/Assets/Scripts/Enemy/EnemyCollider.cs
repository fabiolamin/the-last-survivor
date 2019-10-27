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
            enemyHealth.Change(-10);
            if(enemyHealth.Value <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
