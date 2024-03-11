using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Used for enemies and power-ups to determine if they have collided with the player or not
public class Collidable : MonoBehaviour
{
    // Set to false when it collides with the player. This is to prevent collisions between the player
    // and collidable objects (such as enemies or power-ups) from occuring after the first collision
    public bool collided;
    
    // Collided is initialized to false
    void Start()
    {
        collided = false;
    }
}
