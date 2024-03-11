using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles the SpeedUp (Arrow) Powerup
public class PowerUpSpeedUp : PowerUpCode
{
    float originalSpeed;
    float originalRotation;

    // Doubles the player's rotational and movement speed when activated
    public override void Activate()
    {
        this.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        originalSpeed = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().movementSpeed;
        originalRotation = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().rotationSpeed;
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().movementSpeed = originalSpeed * 2.0f;
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().rotationSpeed = originalRotation * 2.0f;
    }

    // Displays appropriate timer text for the duration of the powerup
    public override void Update()
    {
        if (shouldUpdate)
        {
            // If SpeedUp is active, displays appropriate text
            if (timer < duration)
            {
                GameObject.FindWithTag("Board").transform.GetChild(2).gameObject.GetComponent<DisplayPowerup>().Display("Speed Up: " +  (int)(duration - timer));
                timer = timer + Time.deltaTime;
            }
            // If SpeedUp duration ends, clear powerup text and return the player to original speed
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
