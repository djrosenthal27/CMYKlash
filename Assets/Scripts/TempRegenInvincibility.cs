using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Gives the player temporary invincibility upon recovering a vertex
public class TempRegenInvincibility : MonoBehaviour
{
    GameObject player;

    // Disables the player's colliders and makes them transparent
    public void Restart(GameObject player)
    {
        for (int i = 1; i <= 6; i++)
        {
            player.transform.GetChild(i).gameObject.GetComponent<Collider2D>().enabled = false;
        }

        for (int j = 7; j <= 9; j++) {
            player.transform.GetChild(j).gameObject.transform.GetChild(1).gameObject.SetActive(false);
            player.transform.GetChild(j).gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }


        player.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.2f);

        for (int k = 4; k <= 9; k++)
        {
            player.transform.GetChild(k).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.2f);
        }
    }

    // Reactivates the player's colliders depending on their current state, and makes the player no longer transparent
    public void Reactivate()
    {
        player = GameObject.FindWithTag("Player");

        // Activates triangle colliders if the player is a triangle
        if (player.GetComponent<PlayerMovement>().GetState() == "Triangle")
        {
            for (int i = 1; i <= 3; i++)
            {
                player.transform.GetChild(i).gameObject.GetComponent<Collider2D>().enabled = true;
            }
        } 
        // Activates line colliders if the player is a line
        else if (player.GetComponent<PlayerMovement>().GetState() == "Line")
        {
            for (int j = 7; j <= 9; j++)
            {
                player.transform.GetChild(j).gameObject.transform.GetChild(1).gameObject.SetActive(true);
                player.transform.GetChild(j).gameObject.transform.GetChild(0).gameObject.SetActive(true);
            }
        }

        // Activates vertex colliders regardless of the player's state
        for (int i = 4; i <= 6; i++)
        {
            player.transform.GetChild(i).gameObject.GetComponent<Collider2D>().enabled = true;
        }


        player.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);

        for (int k = 4; k <= 9; k++)
        {
            player.transform.GetChild(k).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        }

    }
}
