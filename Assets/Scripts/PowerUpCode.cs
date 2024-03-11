using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Abstract class containing shared functionality of powerups
public abstract class PowerUpCode : MonoBehaviour
{
    public bool shouldUpdate;
    public float timer;
    public float duration;

    // Initializes timer to 0 and whether the powerup ability should be active to false
    void Start()
    {
        shouldUpdate = false;
        timer = 0;
    }

    // Deactivates the Powerup's collider and sprite but activates its ability
    public void PowerUp()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        shouldUpdate = true;
        Activate();
    }

    // Activates the Powerup's ability. Implemented by subclasses
    abstract public void Activate();

    // Determines what the Powerup ability does on update. Implemented by subclasses
    abstract public void Update();
}
