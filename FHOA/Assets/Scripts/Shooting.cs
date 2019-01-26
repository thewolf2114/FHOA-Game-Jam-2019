using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Basic shooting script for firing bullets from a gun
/// </summary>
public class Shooting : MonoBehaviour
{
    // public variables
    public GameObject bulletPrefab;     // bullet which agent fires
    public float bulletVelocity = 10f;  // velocity at which bullet fires
    public float fireRate = .666f;      // time between shots

    // Update is called once per frame
    void Update()
    {
        // if player is firing
        if (Input.GetAxisRaw("Fire1") != 0)
        {
            // create instance of bullet
            GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * bulletVelocity, ForceMode.Impulse);
        }
    }
}
