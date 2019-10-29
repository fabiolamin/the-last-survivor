using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    Health enemyHealth;
    AttackDamage bulletAttackDamage;

    private void Awake()
    {
        enemyHealth = GetComponent<Health>();
        bulletAttackDamage = GameObject.FindGameObjectWithTag("Bullet").GetComponent<AttackDamage>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            enemyHealth.Change(- bulletAttackDamage.Value);
            if(enemyHealth.Value <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
