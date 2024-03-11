using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles the Power-Spin invincibility mode when a Triangle player obtains the recover Powerup
public class PowerSpin : MonoBehaviour
{
    // Destroys any enemies that collide with the player during the Power-Spin phase
    void OnTriggerEnter2D(Collider2D collider)
    {
        collider.gameObject.GetComponent<Collidable>().collided = true;
        collider.gameObject.GetComponent<Collider2D>().enabled = false;
        GameObject.FindWithTag("Board").GetComponent<ControlPoints>().DefeatEnemy(collider.gameObject);
    }
}
