using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    Health playerHealth;

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            playerHealth.ChangeHealth(-10);
            {
                if (playerHealth.HealthValue <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
