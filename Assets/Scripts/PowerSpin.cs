using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSpin : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        collider.gameObject.GetComponent<Collidable>().collided = true;
        collider.gameObject.GetComponent<Collider2D>().enabled = false;
        Destroy(collider.gameObject, 0.0f);
    }
}
