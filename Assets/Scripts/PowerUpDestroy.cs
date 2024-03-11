using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles the Destroy (Bomb) Powerup
public class PowerUpDestroy : PowerUpCode
{
    Transform enemyBox;

    // Destroys all enemies on screen and updates player's points for each one
    public override void Activate()
    {
        this.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        enemyBox = GameObject.FindWithTag("EnemyBox").transform;
        for (int x = 0; x < enemyBox.childCount; x++)
        {
            GameObject.FindWithTag("Board").GetComponent<ControlPoints>().DefeatEnemy(enemyBox.GetChild(x).gameObject);
        }
    }

    // Displays appropriate timer text for the duration of the Powerup
    public override void Update()
    {
        if (shouldUpdate)
        {

            if (timer < duration)
            {
                GameObject.FindWithTag("Board").transform.GetChild(2).gameObject.GetComponent<DisplayPowerup>().Display("Explode!");
                timer = timer + Time.deltaTime;
            }
            else
            {
                shouldUpdate = false;
                GameObject.FindWithTag("Board").transform.GetChild(2).gameObject.GetComponent<DisplayPowerup>().Display("");
                Destroy(gameObject, 0.0f);
            }

        }
    }
}
