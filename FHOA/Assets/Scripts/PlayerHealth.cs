﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controls player-health system
/// </summary>
public class PlayerHealth : MonoBehaviour
{
    // public variables
    public Image healthBar;                 // scaling bar indicating player health
    public Image profilePicture;            // profile picture ui element
    public Sprite normalProfile;            // profile image to use when player is healthy
    public Sprite hurtPicture;              // profile image to use when player is hurt
    public Sprite nearDeadPicture;          // profile image to use when player is near dead
    public AudioClip[] playerHurtSounds;    // array of sounds to play when player is hurt
    public AudioClip playerDeathSound;      // sound to play when player dies
    public AudioClip corpseHurtSound;       // sound to play when corpse is damaged
    public GameObject enemyExplosion;
    public GameObject deathScreen;
    public float immunityTimer;

    // private variables
    int maxHealth = 100;                // max health of player character
    int currHealth = 100;               // current health of the player character
    bool immune = false;
    float currentImmunityTime = 0;
    RectTransform scalingHealthBar;
    AudioSource audioSource;
    

    // Start is called before the first frame update
    void Start()
    {
        // retrieve proper references to components
        scalingHealthBar = healthBar.GetComponent<RectTransform>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // check for immunity
        if (immune)
        {
            // add time to the current immunity time
            currentImmunityTime += Time.deltaTime;

            // if the current immunity time surpasses the immunity timer
            // reset the current immunity time to 0 and turn off immunity
            if (currentImmunityTime >= immunityTimer)
            {
                currentImmunityTime = 0;
                immune = false;
            }
        }
    }

    /// <summary>
    /// Deducts a set amount of health from the player.
    /// Updates UI elements and transitions to player death
    /// if appropriate.
    /// </summary>
    /// <param name="damage">damage dealt to player</param>
    public void DeductHealth(int damage)
    {
        // deduct damage from health
        currHealth -= damage;

        // if player's health drops below 0, kill player
        if (currHealth <= 0)
        {
            // DUMMY CODE: debug a death log
            //Debug.Log("I have failed you ...");

            // diplay death screen
            DisplayDeathScreen();
        }
        // otherwise (player is still alive)
        else
        {
            // scale health bar size
            scalingHealthBar.localScale = new Vector3((float)currHealth / 100, (float)currHealth / 100, 1);

            // update profile picture as appropriate
            if (currHealth <= 20)
                profilePicture.sprite = nearDeadPicture;
            else if (currHealth <= 70)
                profilePicture.sprite = hurtPicture;
            else
                profilePicture.sprite = normalProfile;

            // play random hurt sound effect
            int hurtSoundIndex = Random.Range(0, playerHurtSounds.Length - 1);
            audioSource.PlayOneShot(playerHurtSounds[hurtSoundIndex]);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // if the enemy touches you and youre not immune
        if (collision.gameObject.tag == "Enemy" && !immune)
        {
            // deduct health and become immune
            DeductHealth(15);
            immune = true;

            // destroy the enemy
            Instantiate(enemyExplosion, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
    }

    public void DisplayDeathScreen()
    {
        // play death sound
        audioSource.PlayOneShot(playerDeathSound);

        // pause the game
        Time.timeScale = 0;

        // display the death screen
        deathScreen.SetActive(true);
    }

    /// <summary>
    /// Plays corpse hurt sound effect from player's audio source
    /// </summary>
    public void PlayCorpseHurtSound()
    {
        // play sound
        audioSource.PlayOneShot(corpseHurtSound);
    }
}
