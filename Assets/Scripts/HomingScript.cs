using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles the Square (Homing) Enemy movement
public class HomingScript : AbstractEnemyScript
{
    public Transform target;
    public float rotateSpeed = 200f;


    private float timer;
    private Rigidbody2D rb;

    // Initializes the enemy's color and the target for them to home in on (the player)
    void Start()
    {
        Initialize();
        timer = 0;
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Rotates and moves the homing enemy toward the player each frame for 10 seconds. After 10 seconds, the enemy no
    // longer follows the player and is destroyed when it goes out-of-bounds
    void FixedUpdate()
    {

        if (timer < 10)
        {
            timer = timer + Time.deltaTime;
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            Vector2 direction = (Vector2)target.position - rb.position;

            direction.Normalize();

            float rotateAmount = Vector3.Cross(direction, transform.up).z;

            rb.angularVelocity = -rotateAmount * rotateSpeed;

            rb.velocity = transform.up * moveSpeed;
        } 
        else
        {
            target = null;
            if (transform.position.x < -14 || transform.position.y < -10 || transform.position.x > 14 || transform.position.y > 10)
            {
                Destroy(gameObject);
            }
        }
    }

    // Destroys the homing enemy
    public void DestroySelf()
    {
        Destroy(this.gameObject, 0.0f);
    }

    // Destroys the homing enemy's child, which is a directional pointer
    public void DestroyChild()
    {
        this.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}
