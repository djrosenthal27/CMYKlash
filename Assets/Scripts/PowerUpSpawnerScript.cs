using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Spawns Powerups in the scene
public class PowerUpSpawnerScript : MonoBehaviour
{
    public float spawnRate;
    public GameObject SpeedUpPlayer;
    public GameObject SlowEnemies;
    public GameObject RecoverVertex;
    public GameObject DestroyEnemies;
    float timer = 0;
    GameObject currentPowerup;

    // Decides on update whether or not to spawn a powerup
    void Update()
    {
        // If PowerUp text is not blank, then a powerup is active, so timer remains at 0
        if (GameObject.FindWithTag("Board").transform.GetChild(2).GetComponent<TextMeshProUGUI>().text != "")
        {
            timer = 0;
        }
        // If PowerUp text is blank and timer is smaller than spawnRate, wait to spawn powerup
        else if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        // If there is not currently a powerup in the scene and the timer reaches the spawn rate, spawn a random powerup
        // in a random part of the scene and reset timer. Odds of spawning different powerups vary
        else if (currentPowerup == null)
        {
            int random = Random.Range(0, 10);
            int randomX = Random.Range(-7, 8);
            int randomY = Random.Range(-3, 4);
            if (random == 9)
            {
                currentPowerup = Instantiate(RecoverVertex, new Vector3(randomX, randomY, 0), Quaternion.identity);
            }
            else if (random == 8 || random == 7)
            {
                currentPowerup = Instantiate(DestroyEnemies, new Vector3(randomX, randomY, 0), Quaternion.identity);
            }
            else if (random == 6 || random == 5 || random == 4)
            {
                currentPowerup = Instantiate(SpeedUpPlayer, new Vector3(randomX, randomY, 0), Quaternion.identity);
            }
            else
            {
                currentPowerup = Instantiate(SlowEnemies, new Vector3(randomX, randomY, 0), Quaternion.identity);
            }
            timer = 0;
        }
        // If there is currently a powerup in the scene but the timer reaches the spawn rate, destroy powerup and reset timer
        else
        {
            Destroy(currentPowerup, 0.0f);
            timer = 0;
        }
    }
}
