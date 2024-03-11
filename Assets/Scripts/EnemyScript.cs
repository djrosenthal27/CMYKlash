using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles the Circle (Normal) Enemy movement
public class EnemyScript : AbstractEnemyScript
{

    private Vector3 dir;

    // Initializes the enemy's color and determines the direction it moves in based on its starting location
    void Start()
    {
        Initialize();
        switch (transform.position.x)
        {
            case 10:
                dir = Vector3.left;
                break;
            case -10:
                dir = Vector3.right;
                break;
        }
        switch (transform.position.y)
        {
            case 6:
                dir = Vector3.down;
                break;
            case -6:
                dir = Vector3.up;
                break;
        }
    }

    // Moves the enemy each frame and destroys the enemy when they are out-of-bounds
    void Update()
    {
        transform.position = transform.position + (dir * moveSpeed * Time.deltaTime);

        if (transform.position.x < -14 || transform.position.y < -10 || transform.position.x > 14 || transform.position.y > 10)
        {
            Destroy(gameObject);
        }
    }

    // Destroys the Circle Enemy
    public void DestroySelf()
    {
        Destroy(this.gameObject, 0.0f);
    }
}
