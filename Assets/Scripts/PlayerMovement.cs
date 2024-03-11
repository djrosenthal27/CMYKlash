using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls the Player's movement abilities
public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public float rotationSpeed;
    public string state;
    float initMoveSpeed;
    float initRotationSpeed;
    Rigidbody2D rb;
    float xMove;
    float yMove;
    int rotation;
    int recentHorizontalDirection;
    int recentVerticalDirection;

    // Initializes variables
    void Start()
    {
        initMoveSpeed = movementSpeed;
        initRotationSpeed = rotationSpeed;
        rb = GetComponent<Rigidbody2D>();
        xMove = 0;
        yMove = 0;
        rotation = 0;
        recentHorizontalDirection = 0;
    }

    // Moves player on update based on button inputs
    void Update()
    {
        if (Input.GetKeyDown("w") || Input.GetKeyDown("z"))
        {
            recentVerticalDirection = 1;
        }
        if (Input.GetKeyDown("s"))
        {
            recentVerticalDirection = -1;
        }
        if (Input.GetKeyDown("a") || Input.GetKeyDown("q"))
        {
            recentHorizontalDirection = -1;
        }
        if (Input.GetKeyDown("d"))
        {
            recentHorizontalDirection = 1;
        }

        yMove = Input.GetAxisRaw("Vertical");
        xMove = Input.GetAxisRaw("Horizontal");

        // If both positive and negative x-axis buttons are pressed, move in the direction of the more-recently 
        // pressed button. Example: if A and D are both pressed but D was pressed after A, move right
        if (xMove == 0 && Input.GetButton("Horizontal"))
        {
            xMove += recentHorizontalDirection;
        }
        // If both positive and negative y-axis buttons are pressed, move in the direction of the more-recently 
        // pressed button. Example: if W and S are both pressed but S was pressed after W, move down
        if (yMove == 0 && Input.GetButton("Vertical"))
        {
            yMove += recentVerticalDirection;
        }
        
        // If the left and/or right arrow keys are pressed, rotate in the direction of the more-recently pressed button
        if (Input.GetKeyDown("right") || (Input.GetKey("right") && !Input.GetKey("left")))
        {
            rotation = -1;
        }
        if (Input.GetKeyDown("left") || (!Input.GetKey("right") && Input.GetKey("left")))
        {
            rotation = 1;
        }
        if (!Input.GetKey("right") && !Input.GetKey("left"))
        {
            rotation = 0;
        }

        rb.velocity = new Vector2(movementSpeed * xMove, movementSpeed * yMove);
        rb.angularVelocity = rotation * rotationSpeed;
    }

    // Sets the player state: Triangle, Line, Dot, or Dead
    public void SetState(string newState)
    {
        state = newState;
    }

    // Returns player state
    public string GetState()
    {
        return state;
    }

    // Returns the player's initial move speed
    public float GetInitMoveSpeed()
    {
        return initMoveSpeed;
    }

    // Returns the player's initial rotation speed
    public float GetInitRotationSpeed()
    {
        return initRotationSpeed;
    }
}
