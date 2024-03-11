using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles player collision
public class PlayerCollision : MonoBehaviour
{

    // Runs when one of the player's colliders comes in contact with a trigger, such as a powerup or enemy
    void OnTriggerEnter2D(Collider2D collider)
    {
        string colliderTag = collider.gameObject.tag;
        string gameObjectTag = this.gameObject.tag;
        GameObject player = GameObject.FindWithTag("Player");

        // Turns off colliding object's collider
        collider.gameObject.GetComponent<Collider2D>().enabled = false;

        // Checks that the colliding object's "collided" value is false
        if (!collider.gameObject.GetComponent<Collidable>().collided)
        {
            // Sets the colliding object's "collided" value to true. This ensures the colliding object doesn't have a repeat
            // collision with one of the player's other colliders
            collider.gameObject.GetComponent<Collidable>().collided = true;

            // Turns off the player's colliders
            for (int i = 1; i <= 6; i++)
            {
                player.transform.GetChild(i).gameObject.GetComponent<Collider2D>().enabled = false;
            }
            
            // If the colliding object is the same color as the side of the Player that it collided with (ex: a magenta enemy
            // colliding with the Player's magenta side), or if it is one of the colors used to create the color of the Player's
            // vertex that it collided with (ex: a yellow or cyan enemy colliding with the Player's green vertex), then it is an
            // enemy which the Player has defeated. The enemy is destroyed and the Player's colliders are turned back on
            if ((colliderTag == "Yellow" && (gameObjectTag == "Yellow" || gameObjectTag == "Red" || gameObjectTag == "Green"))
                || (colliderTag == "Magenta" && (gameObjectTag == "Magenta" || gameObjectTag == "Red" || gameObjectTag == "Blue"))
                || (colliderTag == "Cyan" && (gameObjectTag == "Cyan" || gameObjectTag == "Blue" || gameObjectTag == "Green")))
            {
                GameObject.FindWithTag("Board").GetComponent<ControlPoints>().DefeatEnemy(collider.gameObject);
                for (int i = 1; i <= 6; i++)
                {
                    player.transform.GetChild(i).gameObject.GetComponent<Collider2D>().enabled = true;
                }
            }
            // If the colliding object is a Powerup, then activate the powerup and turn the Player's colliders back on
            else if (colliderTag == "Powerup")
            {
                collider.GetComponent<PowerUpCode>().PowerUp();
                for (int i = 1; i <= 6; i++)
                {
                    player.transform.GetChild(i).gameObject.GetComponent<Collider2D>().enabled = true;
                }
            }
            // If the colliding object isn't either of these things, then the colliding object is an enemy that isn't the same
            // color as the side of the Player it collided with. This enemy does damage to the Player by destroying one Vertex
            else
            {
                // If the Player is a triangle, then a Vertex is destroyed and the player becomes a line
                if (GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().GetState() == "Triangle")
                {

                    // Turn off the triangle sprite and detatch the explosion object
                    player.transform.GetChild(0).gameObject.SetActive(false);
                    GameObject explosion = player.transform.GetChild(10).gameObject;
                    explosion.transform.parent = null;

                    // A vertex is destroyed depending on the collider that the enemy hit
                    if (gameObjectTag == "Yellow" || gameObjectTag == "Green")
                    {
                        TriangleToLine(player.transform.GetChild(6).gameObject, player.transform.GetChild(9).gameObject, 
                            player.transform.GetChild(4).gameObject, "Blue", new Color(0, 0, 255, .13f));
                    }
                    else if (gameObjectTag == "Magenta" || gameObjectTag == "Red")
                    {
                        TriangleToLine(player.transform.GetChild(4).gameObject, player.transform.GetChild(8).gameObject, 
                            player.transform.GetChild(5).gameObject, "Green", new Color(0, 255, 0, .13f));
                    }
                    else if (gameObjectTag == "Cyan" || gameObjectTag == "Blue")
                    {
                        TriangleToLine(player.transform.GetChild(5).gameObject, player.transform.GetChild(7).gameObject, 
                            player.transform.GetChild(6).gameObject, "Red", new Color(255, 0, 0, .13f));
                    }

                    // The player's triangle colliders are turned off
                    for (int h = 1; h <= 3; h++)
                    {
                        player.transform.GetChild(h).gameObject.SetActive(false);
                    }

                    // Play the triangle explosion animation and change the player's current state
                    explosion.GetComponent<Animator>().SetTrigger("Active");
                    GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().SetState("Line");

                }
                // If the Player is a line, then a Vertex is destroyed and the player becomes a dot
                else if (player.GetComponent<PlayerMovement>().GetState() == "Line")
                {
                 
                    // The player's line colliders are turned off
                    for (int j = 7; j <= 9; j++)
                    {
                        player.transform.GetChild(j).gameObject.transform.GetChild(0).gameObject.SetActive(false);
                        player.transform.GetChild(j).gameObject.transform.GetChild(1).gameObject.SetActive(false);
                    }

                    // Pauses player movement and activates line animation for whichever line is active
                    player.GetComponent<PlayerMovement>().movementSpeed = 0;
                    player.GetComponent<PlayerMovement>().rotationSpeed = 0;
                    if (player.transform.GetChild(7).gameObject.activeSelf)
                    { 
                        player.transform.GetChild(7).gameObject.GetComponent<Animator>().SetTrigger("Active");
                    }
                    else if (player.transform.GetChild(8).gameObject.activeSelf)
                    {
                        player.transform.GetChild(8).gameObject.GetComponent<Animator>().SetTrigger("Active");
                    }
                    else if (player.transform.GetChild(9).gameObject.activeSelf)
                    {
                        player.transform.GetChild(9).gameObject.GetComponent<Animator>().SetTrigger("Active");
                    }

                    // A vertex is destroyed based on which vertices are active and which one the colliding enemy is closest to
                    if (player.transform.GetChild(4).gameObject.activeSelf)
                    {
                        if (player.transform.GetChild(5).gameObject.activeSelf)
                        {
                            if (Vector3.Distance(player.transform.GetChild(4).gameObject.transform.position, collider.gameObject.transform.position)
                                > Vector3.Distance(player.transform.GetChild(5).gameObject.transform.position, collider.gameObject.transform.position))
                            {
                                LineToPoint(player.transform.GetChild(5).gameObject, player.transform.GetChild(4).gameObject);
                            }
                            else
                            {
                                LineToPoint(player.transform.GetChild(4).gameObject, player.transform.GetChild(5).gameObject);
                            }
                        }
                        else
                        {
                            if (Vector3.Distance(player.transform.GetChild(4).gameObject.transform.position, collider.gameObject.transform.position)
                                > Vector3.Distance(player.transform.GetChild(6).gameObject.transform.position, collider.gameObject.transform.position))
                            {
                                LineToPoint(player.transform.GetChild(6).gameObject, player.transform.GetChild(4).gameObject);
                            }
                            else
                            {
                                LineToPoint(player.transform.GetChild(4).gameObject, player.transform.GetChild(6).gameObject);
                            }
                        }
                    }
                    else
                    {
                        if (Vector3.Distance(player.transform.GetChild(6).gameObject.transform.position, collider.gameObject.transform.position)
                            > Vector3.Distance(player.transform.GetChild(5).gameObject.transform.position, collider.gameObject.transform.position))
                        {
                            LineToPoint(player.transform.GetChild(5).gameObject, player.transform.GetChild(6).gameObject);
                        }
                        else
                        {
                            LineToPoint(player.transform.GetChild(6).gameObject, player.transform.GetChild(5).gameObject);
                        }
                    }

                    GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().SetState("Dot");
                }
                // If the Player is a dot, then the vertex is destroyed and the player loses
                else if (player.GetComponent<PlayerMovement>().GetState() == "Dot")
                {
                    // Player state is set to dead and player stops moving
                    GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().SetState("Dead");

                    player.GetComponent<PlayerMovement>().movementSpeed = 0;
                    player.GetComponent<PlayerMovement>().rotationSpeed = 0;

                    // Active vertex is destroyed
                    if (player.transform.GetChild(4).gameObject.activeSelf)
                    {
                        player.transform.GetChild(4).gameObject.transform.GetChild(1).GetComponent<Animator>().SetTrigger("Active");
                    }
                    else if (player.transform.GetChild(5).gameObject.activeSelf)
                    {
                        player.transform.GetChild(5).gameObject.transform.GetChild(1).GetComponent<Animator>().SetTrigger("Active");
                    }
                    else if (player.transform.GetChild(6).gameObject.activeSelf)
                    {
                        player.transform.GetChild(6).gameObject.transform.GetChild(1).GetComponent<Animator>().SetTrigger("Active");
                    }
                }

                // In the event that the colliding object is not destroyed (meaning the colliding object is an enemy which damaged
                // the player), the colliding object becomes transparent
                collider.gameObject.GetComponent<SpriteRenderer>().color = new Color(200, 200, 200, 0.2f);

            }
        }
    }

    // Helper function for changing the Player from a triangle to a line
    private void TriangleToLine(GameObject explodingVertex, GameObject line, GameObject remainingVertex, string colorText, Color color)
    {
        explodingVertex.transform.GetChild(1).GetComponent<Animator>().SetTrigger("Active");
        line.SetActive(true);
        remainingVertex.tag = colorText;
        remainingVertex.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = color;
    }

    // Helper function for changing the Player from a line to a dot
    private void LineToPoint(GameObject explodingVertex, GameObject remainingVertex)
    {
        explodingVertex.transform.GetChild(1).GetComponent<Animator>().SetTrigger("Active");
        remainingVertex.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, .13f);
        remainingVertex.tag = "Black";
    }

}

