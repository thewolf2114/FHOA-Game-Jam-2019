using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemy;
    public GameObject[] spawnPoints;
    public GameObject fireComplexEffect;
    public int zombieCount;
    public float spawnTimer;
    public GameObject player;
    public GameObject corpseTarget;
    public float chanceToTargetPlayer = .95f;
    int currentZombieCount = 0;
    float currentTimer = 0;
    bool canSpawn = true;

    public int CurrentZombieCount
    {
        get { return currentZombieCount; }
        set { currentZombieCount -= value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // update the current zombie counter
        currentZombieCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (currentTimer >= spawnTimer)
        {
            currentTimer = 0;
            canSpawn = true;
        }

        if (currentZombieCount < zombieCount && canSpawn)
        {
            // randomly generate a number based on how many spawn points are in the game
            int randomSpawn = Random.Range(0, spawnPoints.Length);

            // spawn the enemy at a spawn point
            Instantiate(enemy, spawnPoints[randomSpawn].transform.position, Quaternion.identity);

            // set enemy's random target
            float randTarget = Random.Range(0, 1);
            if (randTarget < chanceToTargetPlayer)
                enemy.GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>().SetTarget(player.transform);
            else
                enemy.GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>().SetTarget(corpseTarget.transform);

            // spawn the fire effect
            Instantiate(fireComplexEffect, spawnPoints[randomSpawn].transform.position, Quaternion.identity);

            //set can spawn to false to space out the enemy spawning
            canSpawn = false;
        }

        if (!canSpawn)
        {
            currentTimer += Time.deltaTime;
        }
    }
}
