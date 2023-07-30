using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeedUp : PowerUpCode
{
    float originalSpeed;
    float originalRotation;

    public override void Activate()
    {
        this.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        originalSpeed = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().movementSpeed;
        originalRotation = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().rotationSpeed;
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().movementSpeed = originalSpeed * 2.0f;
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().rotationSpeed = originalRotation * 2.0f;
    }

    public override void Update()
    {
        if (shouldUpdate)
        {

            if (timer < duration)
            {
                GameObject.FindWithTag("Board").transform.GetChild(2).gameObject.GetComponent<DisplayPowerup>().Display("Speed Up: " +  (int)(duration - timer));
                timer = timer + Time.deltaTime;
            }
            else
            {
                GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().movementSpeed = originalSpeed;
                GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().rotationSpeed = originalRotation;
                shouldUpdate = false;
                GameObject.FindWithTag("Board").transform.GetChild(2).gameObject.GetComponent<DisplayPowerup>().Display("");
                Destroy(gameObject, 0.0f);
            }

        }
    }
}
