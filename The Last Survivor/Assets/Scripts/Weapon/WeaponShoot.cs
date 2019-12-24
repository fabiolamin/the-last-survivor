using UnityEngine;

public class WeaponShoot : MonoBehaviour
{
    private AttackDamage weaponAttackDamage;
    private Ammo ammo;
    private GameObject target;

    private void Awake()
    {
        weaponAttackDamage = GetComponent<AttackDamage>();
        ammo = GetComponent<Ammo>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (ammo.Amount > 0)
            {
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        ammo.Change(-1);

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray.origin, ray.direction, out hit, 25f))
        {
            target = hit.collider.gameObject;
            VerifyTarget();
        }
    }

    private void VerifyTarget()
    {
        if (target.CompareTag("Enemy"))
        {
            DamageTarget();
        }
    }

    private void DamageTarget()
    {
        Health targetHealth = target.GetComponent<Health>();
        targetHealth.Change(-weaponAttackDamage.Value);
    }
}
