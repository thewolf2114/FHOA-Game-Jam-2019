using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Facilitates the health management of the corpse
/// </summary>
public class CorpseHealth : MonoBehaviour
{
    // public variables
    public GameObject enemyExplosion;
    public Image healthBar;
    public int enemyDamage = 10;

    // private variables
    int health = 100;
    RectTransform scalingHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        // retrieve proper component references
        scalingHealthBar = healthBar.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // if the enemy touches you and youre not immune
        if (collision.gameObject.tag == "Enemy")
        {
            // destroy the ghoul
            Instantiate(enemyExplosion, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);

            // deduct appropriate health
            DeductHealth(enemyDamage);
        }
    }

    /// <summary>
    /// Deducts set amount of health from corpse's health pool
    /// </summary>
    /// <param name="damage"></param>
    public void DeductHealth(int damage)
    {
        // deduct health from pool
        health -= damage;

        // if corpse survives attack
        if (health > 0)
        {
            // scale corpse health bar's size
            scalingHealthBar.localScale = new Vector3((float)health / 100, (float)health / 100, 1);

            // play hurt corpse sound effect from player
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().PlayCorpseHurtSound();
        }
        // otherwise (player failed to protect corpse)
        else
        {
            // send player to 'game over' screen
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().DisplayDeathScreen();

            // play hurt corpse sound effect from player
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().PlayCorpseHurtSound();
        }
    }
}
