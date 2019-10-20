using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private float speed = 100f;
  
    private void FixedUpdate()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            Rigidbody newBulletRigidbody = newBullet.GetComponent<Rigidbody>();
            newBulletRigidbody.velocity += transform.forward * speed;
            Destroy(newBullet,3f);
        }
    }
}
