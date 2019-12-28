using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    private EnemyAnimation enemyAnimation;
    private void Awake()
    {
        enemyAnimation = GetComponent<EnemyAnimation>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemyAnimation.IsAttacking = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemyAnimation.IsAttacking = false;
        }
    }
}
