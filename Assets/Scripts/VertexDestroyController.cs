using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles the destruction of player vertices
public class VertexDestroyController : MonoBehaviour
{
    Transform parent;

    // Enables the vertex destruction sprite, removes the vertex sprite, and detatches vertex from player
    public void RemoveSprite()
    {
        parent = this.gameObject.transform.parent;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        parent.GetComponent<SpriteRenderer>().enabled = false;
        parent.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        this.gameObject.transform.parent = null;
    }

    // Deactivates the vertex after it shatters. If the Player was a dot, then the player is dead, and the pause
    // screen appears with the "Resume" option replaced by game-over text
    public void Delete()
    {
        parent.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
        if (GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().GetState() == "Dead")
        {
            GameObject.FindWithTag("Board").transform.GetChild(4).gameObject.SetActive(true);
            GameObject.FindWithTag("Board").transform.GetChild(4).GetChild(0).gameObject.SetActive(false);
            GameObject.FindWithTag("Board").transform.GetChild(4).GetChild(3).gameObject.SetActive(true);
        }
    }
}
