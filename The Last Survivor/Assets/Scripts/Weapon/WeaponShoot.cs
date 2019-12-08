using UnityEngine;

public class WeaponShoot : MonoBehaviour
{
    private AttackDamage weaponAttackDamage;

    private void Awake()
    {
        weaponAttackDamage = GetComponent<AttackDamage>();
    }
    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray.origin, ray.direction, out hit, 25f))
        {
            GameObject target = hit.collider.gameObject;
            VerifyTarget(target);
        }
    }

    private void VerifyTarget(GameObject target)
    {
        if (target.CompareTag("Enemy"))
        {
            DamageEnemy(target);
        }
    }

    private void DamageEnemy(GameObject enemy)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Health enemyHealth = enemy.GetComponent<Health>();
            enemyHealth.Change(-weaponAttackDamage.Value);
        }
    }
}
