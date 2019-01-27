using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script facilitating the health management of enemy agents
/// </summary>
public class EnemyHealth : MonoBehaviour
{
    // public variables
    public int health = 3;      // number of shots enemy can take before dying
    public GameObject explosion;

    // private variables
    PlayerKillCounter killCounter;  // used to increment player's kill counter upon enemy death

    // Start is called before the first frame update
    void Start()
    {
        // retrieve kill counter component from the player character
        killCounter = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerKillCounter>();
    }

    /// <summary>
    /// Called when an object collides with this agent
    /// </summary>
    /// <param name="collision">collision box of other object</param>
    void OnCollisionEnter(Collision collision)
    {
        // if other object in collision was a bullet
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // decrement health of agent
            health--;

            // destroy bullet and agent if appropriate
            Destroy(collision.gameObject);
            if (health <= 0)
            {
                // destroy agent
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);

                // increment player's kill count
                killCounter.IncrementKillCount();
            }
        }
    }
}
