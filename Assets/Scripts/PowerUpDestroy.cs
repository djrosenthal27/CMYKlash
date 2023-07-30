using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDestroy : PowerUpCode
{
    Transform enemyBox;
    public override void Activate()
    {
        Debug.Log("Kaboom!");
        this.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        enemyBox = GameObject.FindWithTag("EnemyBox").transform;
        for (int x = 0; x < enemyBox.childCount; x++)
        {
            Destroy(enemyBox.GetChild(x).gameObject, 0.0f);
        }
    }

    public override void Update()
    {
        if (shouldUpdate)
        {

            if (timer < duration)
            {
                timer = timer + Time.deltaTime;
            }
            else
            {
                shouldUpdate = false;
                Destroy(gameObject, 0.0f);
            }

        }
    }
}
