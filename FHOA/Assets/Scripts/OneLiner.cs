using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script controlling one-liners that player character
/// says at different periods throughout the game
/// </summary>
public class OneLiner : MonoBehaviour
{
    // public variables
    public AudioSource audioSource;            // source to play one-liners from
    public AudioClip[] openingOneLiners;       // array of one-liners to play at start of the game

    // Start is called before the first frame update
    void Start()
    {
        // choose and play random one-liner
        int oneLinerIndex = Random.Range(0, openingOneLiners.Length - 1);
        audioSource.PlayOneShot(openingOneLiners[oneLinerIndex]);
    }
}
