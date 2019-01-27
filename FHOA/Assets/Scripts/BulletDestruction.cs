using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles destruction of projectile after a set period of time
/// or collision.
/// </summary>
public class BulletDestruction : MonoBehaviour
{
    // public variables
    public float projectileLifespan;        // time before a bullet destroys itself
    public GameObject bloodyShotParticle;   // particle effect that plays when bullet hits 

    // private variables
    float lifeCounter = 0;                  // counter incrementing age of bullet (before it dies)

    // Update is called once per frame
    void Update()
    {
        // increment life counter
        lifeCounter += Time.deltaTime;

        // if counter exceeds max time, destroy bullet
        if (lifeCounter >= projectileLifespan)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// When projectile object collides with another object
    /// </summary>
    /// <param name="collision">collider of the other object</param>
    void OnCollisionEnter(Collision collision)
    {
        // if bullet collides with a ghoul
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // create instance of missed shot particle effect
            Vector3 fireSpawnPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Instantiate(bloodyShotParticle, fireSpawnPoint, Quaternion.identity);
        }

        // destroy projectile
        Destroy(gameObject);
    }
}
