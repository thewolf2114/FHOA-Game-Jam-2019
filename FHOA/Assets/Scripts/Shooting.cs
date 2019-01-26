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
    public GameObject bulletSpawnPoint; // point at which to spawn bullets from
    public float bulletVelocity = 10f;  // velocity at which bullet fires
    public float fireRate = .666f;      // time between shots

    // private variables
    bool canShoot = true;               // flag determining whether player can fire bullet on given frame
    float fireFrameCounter = 0;         // counter aiding in fire rate

    // Update is called once per frame
    void Update()
    {
        // if counter exceeds time between shots
        if (fireFrameCounter >= fireRate)
        {
            // reset can shoot flag and fire rate counter
            canShoot = true;
            fireFrameCounter = 0;
        }
        // otherwise (counter has not exceeded limit)
        else
            // increment timer with time between frames
            fireFrameCounter += Time.deltaTime;

        // if player is firing
        if (Input.GetAxisRaw("Fire1") != 0 && canShoot)
        {
            // create instance of bullet
            GameObject newBullet = Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * bulletVelocity, ForceMode.Impulse);

            // set gun to unable to fire
            canShoot = false;
        }
    }
}
