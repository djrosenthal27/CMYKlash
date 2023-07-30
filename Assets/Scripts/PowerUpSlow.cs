using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSlow : PowerUpCode
{
    Transform enemyBox;
    public override void Activate()
    {
        Debug.Log("it's slow time!");
        this.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        enemyBox = GameObject.FindWithTag("EnemyBox").transform;
        for (int x = 0; x < enemyBox.childCount; x++) {
            Debug.Log(enemyBox);
            Debug.Log(enemyBox.GetChild(x));
            Debug.Log(enemyBox.GetChild(x).gameObject.GetComponent<EnemyScript>());
            Debug.Log(enemyBox.GetChild(x).gameObject.GetComponent<AbstractEnemyScript>().moveSpeed);
           
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
                timer = timer + Time.deltaTime;
            }
            else
            {
                
                for (int x = 0; x < enemyBox.childCount; x++)
                {
                    enemyBox.GetChild(x).gameObject.GetComponent<AbstractEnemyScript>().moveSpeed = enemyBox.GetChild(x).gameObject.GetComponent<AbstractEnemyScript>().moveSpeed * 2.0f;
                }
                enemyBox.GetComponent<SlowedDown>().slowedDown = false;
                shouldUpdate = false;
                Destroy(gameObject, 0.0f);
            }

        }
    }
}
