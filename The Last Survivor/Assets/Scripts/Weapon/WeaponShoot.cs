using UnityEngine;

public class WeaponShoot : MonoBehaviour
{
    private AttackDamage weaponAttackDamage;
    private Ammo ammo;
    private GameObject target;
    private AudioSource audioSource;
    [SerializeField]
    private ParticleSystem particle;
    [SerializeField]
    private AudioClip[] audioClips;

    private void Awake()
    {
        weaponAttackDamage = GetComponent<AttackDamage>();
        ammo = GetComponent<Ammo>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (ammo.Amount > 0)
            {
                Shoot();
            }

            audioSource.PlayOneShot(audioClips[1]);
        }
    }

    private void Shoot()
    {
        audioSource.PlayOneShot(audioClips[0]);
        particle.Play();
        ammo.Change(-1);

        Ray ray = new Ray(transform.position + (Vector3.up * 0.15f), -transform.right);
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
