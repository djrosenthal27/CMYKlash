using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public float rotationSpeed;
    Rigidbody2D rb;
    int xMove;
    int yMove;
    int rotation;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        xMove = 0;
        yMove = 0;
        rotation = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w")) 
        {
            yMove = 1;
        }
        if (Input.GetKeyDown("s"))
        {
            yMove = -1;
        }
        if (!Input.GetKey("w") && !Input.GetKey("s"))
        {
            yMove = 0;
        }
        if (Input.GetKeyDown("d"))
        {
            xMove = 1;
        }
        if (Input.GetKeyDown("a"))
        {
            xMove = -1;
        }
        if (!Input.GetKey("d") && !Input.GetKey("a"))
        {
            xMove = 0;
        }
        if (Input.GetKeyDown("right"))
        {
            rotation = -1;
        }
        if (Input.GetKeyDown("left"))
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
}
