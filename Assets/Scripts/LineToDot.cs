using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Assists with animating the Player's transformation from a line to a dot
public class LineToDot : MonoBehaviour
{
    float movementSpeed;
    float rotationSpeed;

    // Initializes the movementSpeed and rotationSpeed
    void Start()
    {
        movementSpeed = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().GetInitMoveSpeed();
        rotationSpeed = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().GetInitRotationSpeed();
    }

    // Allows the player to move and makes their vertices transparent
    public void MakeTransparent()
    {
        GameObject player = GameObject.FindWithTag("Player");

        player.GetComponent<PlayerMovement>().movementSpeed = movementSpeed;
        player.GetComponent<PlayerMovement>().rotationSpeed = rotationSpeed;

        for (int i = 4; i <= 6; i++)
        {
            player.transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.2f);
        }
    }

    // Detatches the line from the player
    public void Detatch()
    {
        this.transform.parent = null;
    }


    // Reactivates the vertices' colliders and makes them no longer transparent. Deactivates the line
    public void Reactivate()
    {
        GameObject player = GameObject.FindWithTag("Player");

        for (int i = 4; i <= 6; i++)
        {
            player.transform.GetChild(i).gameObject.GetComponent<CircleCollider2D>().enabled = true;
            player.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        }

        this.gameObject.SetActive(false);
    }


}
