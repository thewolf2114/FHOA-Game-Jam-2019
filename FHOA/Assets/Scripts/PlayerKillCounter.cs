using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script facilitating kill counter updates and playing
/// kill-dependent voice lines
/// </summary>
public class PlayerKillCounter : MonoBehaviour
{
    // public variables
    public Text killCounter;            // text displaying player's current number of kills
    public AudioSource audioSource;     // source to play enemy death sounds from
    public AudioClip enemyDeathSound;   // sound which plays when enemy dies

    // private variables
    int killCount = 0;              // current number of kills

    // Start is called before the first frame update
    void Start()
    {
        // initialize kill counter to 0
        killCounter.text = "Kills: " + killCount;
    }

    // Update() calls itself once per frame
    void Update()
    {
        // TEST: if player presses 'l', increment kill count
        if (Input.GetKeyDown(KeyCode.L))
            IncrementKillCount();
    }

    /// <summary>
    /// Increments kill count
    /// </summary>
    void IncrementKillCount()
    {
        // increment kill count
        killCount++;
        killCounter.text = "Kills: " + killCount;

        // play enemy death sound effect
        audioSource.PlayOneShot(enemyDeathSound);
    }
}
