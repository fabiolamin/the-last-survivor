using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShoot : MonoBehaviour
{
    AttackDamage weaponAttackDamage;

    private void Awake()
    {
        weaponAttackDamage = GetComponent<AttackDamage>();
    }
    private void FixedUpdate()
    {
        Debug.DrawRay(transform.position, transform.forward * 25f, Color.red);
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position, transform.forward, out hit, 25f))
            {
                GameObject gameObject = hit.collider.gameObject;
                if (gameObject.CompareTag("Enemy"))
                {
                    Health enemyHealth = gameObject.GetComponent<Health>();
                    enemyHealth.Change(-weaponAttackDamage.Value);
                }
            }
        }
    }
}
