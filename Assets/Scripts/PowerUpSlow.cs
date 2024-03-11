using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles the SlowDown (Weight) Powerup
public class PowerUpSlow : PowerUpCode
{
    Transform enemyBox;

    // Halves the speed of all active enemies on screen
    public override void Activate()
    {
        this.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        enemyBox = GameObject.FindWithTag("EnemyBox").transform;
        for (int x = 0; x < enemyBox.childCount; x++) {           
            enemyBox.GetChild(x).gameObject.GetComponent<AbstractEnemyScript>().moveSpeed /= 2.0f;
        }
        enemyBox.GetComponent<SlowedDown>().isSlowedDown = true;
    }

    // Displays appropriate timer text for the duration of the powerup
    public override void Update()
    {
        if (shouldUpdate)
        {
            enemyBox = GameObject.FindWithTag("EnemyBox").transform;

            // While SlowDown is active, display appropriate text
            if (timer < duration)
            {
                GameObject.FindWithTag("Board").transform.GetChild(2).gameObject.GetComponent<DisplayPowerup>().Display("Slow Down: " + (int)(duration - timer));
                timer = timer + Time.deltaTime;
            }
            // When SlowDown duration ends, clear powerup texts and return enemies to normal speed
            else
            {
                
                for (int x = 0; x < enemyBox.childCount; x++)
                {
                    enemyBox.GetChild(x).gameObject.GetComponent<AbstractEnemyScript>().moveSpeed 
                        = enemyBox.GetChild(x).gameObject.GetComponent<AbstractEnemyScript>().moveSpeed * 2.0f;
                }
                GameObject.FindWithTag("Board").transform.GetChild(2).gameObject.GetComponent<DisplayPowerup>().Display("");
                enemyBox.GetComponent<SlowedDown>().isSlowedDown = false;
                shouldUpdate = false;
                Destroy(gameObject, 0.0f);
            }

        }
    }
}
