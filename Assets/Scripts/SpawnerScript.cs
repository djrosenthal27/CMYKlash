using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Spawns enemies in random spots in the scene
public class SpawnerScript : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Homing;
    public float spawnRate = 2;
    public float spawnSpeedUpValue1;
    public float spawnSpeedUpValue2;
    public int homingRate;
    public Transform box;

    float timer = 0;
    float overallTimer;

    // Initializes overall time to 0
    void Start()
    {
        overallTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Decrease spawn rate by spawnSpeedUpValue1 every 20 seconds until it reaches 0.5f
        if (overallTimer > 20 && spawnRate - spawnSpeedUpValue1 >= 0.5f)
        {
            overallTimer = 0;
            spawnRate = spawnRate - spawnSpeedUpValue1;
        }
        // Past 0.5f spawn rate, decrease spawn rate by spawnSpeedUpValue2 every 20 seconds until it reaches 0.3f
        else if (overallTimer > 20 && spawnRate - spawnSpeedUpValue2 >= 0.3f)
        {
            overallTimer = 0;
            spawnRate = spawnRate - spawnSpeedUpValue2;
        }
        // Increment overall timer when it isn't at 20 seconds
        else
        {
            overallTimer = overallTimer + Time.deltaTime;
        }

        int x, y;

        // Increment timer when it hasn't reached spawn rate
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        // If the timer has reached the spawn rate and the EnemyBox isn't affected by SlowDown, instantiate
        // a random enemy in a random spot off-screen and reset timer. Odds of enemy-types vary
        else if (!box.GetComponent<SlowedDown>().isSlowedDown)
        {
            if (Random.Range(0, 2) == 0)
            {
                if (Random.Range(0, 2) == 0)
                {
                    y = Random.Range(-4, 4);
                    x = 10;
                }
                else
                {
                    y = Random.Range(-4, 4);
                    x = -10;
                }
            }
            else
            {
                if (Random.Range(0, 2) == 0)
                {
                    x = Random.Range(-9, 9);
                    y = 6;
                }
                else
                {
                    x = Random.Range(-4, 4);
                    y = -6;
                }
            }

            // Chance of spawning a HomingEnemy when prefab is provided
            if (Homing != null && Random.Range(0, homingRate) == 0)
            {
                Instantiate(Homing, new Vector3(x, y, transform.position.z), transform.rotation, box);
            }
            else
            {
                Instantiate(Enemy, new Vector3(x, y, transform.position.z), transform.rotation, box);
            }

            timer = 0;
        }
    }
}
