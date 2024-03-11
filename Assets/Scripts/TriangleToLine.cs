using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Assists with animating the Player's transformation from a tirangle to a line
public class TriangleToLine : MonoBehaviour
{
    public GameObject player;
    float movementSpeed;
    float rotationSpeed;

    // Initializes the movementSpeed and rotationSpeed
    void Start()
    {
        movementSpeed = player.GetComponent<PlayerMovement>().movementSpeed;
        rotationSpeed = player.GetComponent<PlayerMovement>().rotationSpeed;
    }

    // Halts the player's movement and rotation
    public void Stop()
    {
        player.GetComponent<PlayerMovement>().movementSpeed = 0;
        player.GetComponent<PlayerMovement>().rotationSpeed = 0;
    }

    // Allows the player to move and makes their vertices and lines transparent
    public void MakeTransparent()
    {

        for (int i = 4; i <= 9; i++)
        {
            player.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.2f);
        }

        player.GetComponent<PlayerMovement>().movementSpeed = movementSpeed;
        player.GetComponent<PlayerMovement>().rotationSpeed = rotationSpeed;
    }

    // Reactivates the vertex and line colliders and makes them no longer transparent
    public void Reactivate()
    {
        for (int j = 7; j <= 9; j++)
        {
            player.transform.GetChild(j).gameObject.transform.GetChild(1).gameObject.SetActive(true);
            player.transform.GetChild(j).gameObject.transform.GetChild(0).gameObject.SetActive(true);
            player.transform.GetChild(j).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        }

        for (int k = 4; k <= 6; k++)
        {
            player.transform.GetChild(k).gameObject.GetComponent<CircleCollider2D>().enabled = true;
            player.transform.GetChild(k).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        }
    }
}
