using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeedUp : PowerUpCode
{
    float originalSpeed;
    float originalRotation;

    public override void Activate()
    {
        Debug.Log("Speed");
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
                timer = timer + Time.deltaTime;
            }
            else
            {
                GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().movementSpeed = originalSpeed;
                GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().rotationSpeed = originalRotation;
                shouldUpdate = false;
                Destroy(gameObject, 0.0f);
            }

        }
    }
}
