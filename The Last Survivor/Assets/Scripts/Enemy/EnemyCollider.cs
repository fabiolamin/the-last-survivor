using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    private Health enemyHealth;
    private AttackDamage bulletAttackDamage;

    private void Awake()
    {
        enemyHealth = GetComponent<Health>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            bulletAttackDamage = collision.gameObject.GetComponent<AttackDamage>();
            enemyHealth.Change(- bulletAttackDamage.Value);
            if(enemyHealth.Value <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
