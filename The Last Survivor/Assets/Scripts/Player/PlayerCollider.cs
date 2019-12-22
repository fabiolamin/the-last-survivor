using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private Health playerHealth;
    private AttackDamage enemyAttackDamage;

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            enemyAttackDamage = collision.gameObject.GetComponent<AttackDamage>();
            playerHealth.Change(- enemyAttackDamage.Value);
            {
                if (playerHealth.Amount <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
