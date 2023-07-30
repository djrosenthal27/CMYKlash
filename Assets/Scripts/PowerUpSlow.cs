using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSlow : PowerUpCode
{
    Transform enemyBox;
    public override void Activate()
    {
        this.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        enemyBox = GameObject.FindWithTag("EnemyBox").transform;
        for (int x = 0; x < enemyBox.childCount; x++) {           
            enemyBox.GetChild(x).gameObject.GetComponent<AbstractEnemyScript>().moveSpeed = enemyBox.GetChild(x).gameObject.GetComponent<AbstractEnemyScript>().moveSpeed / 2.0f;
        }
        enemyBox.GetComponent<SlowedDown>().slowedDown = true;
    }

    public override void Update()
    {
        if (shouldUpdate)
        {
            enemyBox = GameObject.FindWithTag("EnemyBox").transform;

            if (timer < duration)
            {
                GameObject.FindWithTag("Board").transform.GetChild(2).gameObject.GetComponent<DisplayPowerup>().Display("Slow Down: " + (int)(duration - timer));
                timer = timer + Time.deltaTime;
            }
            else
            {
                
                for (int x = 0; x < enemyBox.childCount; x++)
                {
                    enemyBox.GetChild(x).gameObject.GetComponent<AbstractEnemyScript>().moveSpeed = enemyBox.GetChild(x).gameObject.GetComponent<AbstractEnemyScript>().moveSpeed * 2.0f;
                }
                GameObject.FindWithTag("Board").transform.GetChild(2).gameObject.GetComponent<DisplayPowerup>().Display("");
                enemyBox.GetComponent<SlowedDown>().slowedDown = false;
                shouldUpdate = false;
                Destroy(gameObject, 0.0f);
            }

        }
    }
}
