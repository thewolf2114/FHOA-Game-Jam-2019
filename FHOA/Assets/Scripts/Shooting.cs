using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Basic shooting script for firing bullets from a gun
/// </summary>
public class Shooting : MonoBehaviour
{
    // public variables
    public GameObject bulletPrefab;     // bullet which agent fires
    public GameObject bulletSpawnPoint; // point at which to spawn bullets from
    public GameObject gunAction;        // action of gun that slides back on fire
    public GameObject fireParticle;     // visual effect that plays when player fires
    public Text ammoCount;              // text object showing current ammo
    public AudioSource audioSource;     // source to play shooting sounds from
    public AudioClip shotSound;         // gun shot sound effect
    public int maxAmmo = 50;            // number of bullets gun resets to after player reloads
    public float bulletVelocity = 10f;  // velocity at which bullet fires
    public float fireRate = .666f;      // time between shots

    // private variables
    int currAmmo = 0;                   // current number of shots in player's gun
    bool canShoot = true;               // flag determining whether player can fire bullet on given frame
    float fireFrameCounter = 0;         // counter aiding in fire rate
    Vector3 actionStartPosition;        // starting position of gun action
    Vector3 actionFirePosition;         // position of gun action when gun fires a bullet

    // Called a frame before first Update()
    void Start()
    {
        // initialize player's gun to full magazine
        currAmmo = maxAmmo;
        ammoCount.text = "Ammo: " + currAmmo;

        // save initial and firing positions of gun action
        actionStartPosition = gunAction.transform.localPosition;
        actionFirePosition = new Vector3(actionStartPosition.x, actionStartPosition.y, -.01f);
    }

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

        // if player is firing, can shoot, and has ammo to fire
        if (Input.GetAxisRaw("Fire1") != 0 && canShoot && currAmmo > 0)
        {
            // fire bullet in direction player faces
            GameObject newBullet = Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * bulletVelocity, ForceMode.Impulse);

            // create instance of fire visual effect
            Instantiate(fireParticle, bulletSpawnPoint.transform.position, Quaternion.identity);

            // move action back to fire position
            gunAction.transform.localPosition = actionFirePosition;

            // play gun shot sound effect
            audioSource.PlayOneShot(shotSound);

            // decrement ammo count and set gun to unable to fire
            currAmmo--;
            ammoCount.text = "Ammo: " + currAmmo;
            canShoot = false;
        }
        // otherwise (player isn't shooting)
        else
            // move action back to starting position
            gunAction.transform.localPosition = actionStartPosition;

        // if player presses reload button while not firing
        if (Input.GetKeyDown(KeyCode.R) && Input.GetAxisRaw("Fire1") == 0)
        {
            // reset current ammo
            currAmmo = maxAmmo;
            ammoCount.text = "Ammo: " + currAmmo;

            // TODO: play reload sound effect

        }
    }
}
