using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemy;
    public GameObject[] spawnPoints;
    public int zombieCount;
    public float spawnTimer;
    public GameObject player;
    int currentZombieCount = 0;
    float currentTimer = 0;
    bool canSpawn = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
            enemy.GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>().SetTarget(player.transform);

            // increment the current zombie counter
            currentZombieCount++;

            //set can spawn to false to space out the enemy spawning
            canSpawn = false;
        }

        if (!canSpawn)
        {
            currentTimer += Time.deltaTime;
        }
    }
}
