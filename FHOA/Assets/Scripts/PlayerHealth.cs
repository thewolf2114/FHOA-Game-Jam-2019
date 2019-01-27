using System.Collections;
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

    // private variables
    int maxHealth = 100;                // max health of player character
    int currHealth = 100;               // current health of the player character
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
        // TEST: hurt player on pressing 'k'
        if (Input.GetKeyDown(KeyCode.K))
            DeductHealth(10);
    }

    /// <summary>
    /// Deducts a set amount of health from the player.
    /// Updates UI elements and transitions to player death
    /// if appropriate.
    /// </summary>
    /// <param name="damage">damage dealt to player</param>
    void DeductHealth(int damage)
    {
        // deduct damage from health
        currHealth -= damage;

        // if player's health drops below 0, kill player
        if (currHealth <= 0)
        {
            // DUMMY CODE: debug a death log
            Debug.Log("I have failed you ...");

            // play death sound
            audioSource.PlayOneShot(playerDeathSound);
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
            int hurtSoundIndex = Random.Range(0, playerHurtSounds.Length);
            audioSource.PlayOneShot(playerHurtSounds[hurtSoundIndex]);
        }
    }
}
