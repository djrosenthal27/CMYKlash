using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    /*
    public PolygonCollider2D cyanCollider;
    public PolygonCollider2D magentaCollider;
    public PolygonCollider2D yellowCollider;
    */

    void OnTriggerEnter2D(Collider2D collider)
    {
        ProcessCollision(collider);
    }

    void ProcessCollision(Collider2D collider)
    {
        string colliderTag = collider.gameObject.tag;
        string gameObjectTag = this.gameObject.tag;
        GameObject player = GameObject.FindWithTag("Player");
        if ((colliderTag == "Yellow" && (gameObjectTag == "Yellow" || gameObjectTag == "Red" || gameObjectTag == "Green"))
            || (colliderTag == "Magenta" && (gameObjectTag == "Magenta" || gameObjectTag == "Red" || gameObjectTag == "Blue"))
            || (colliderTag == "Cyan" && (gameObjectTag == "Cyan" || gameObjectTag == "Blue" || gameObjectTag == "Green")))
        {
            collider.gameObject.SetActive(false);

        }
        else
        {
            if (GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().GetState() == "Triangle")
            {
                player.transform.GetChild(0).gameObject.SetActive(false);
                //  player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;       
                GameObject explosion = player.transform.GetChild(1).gameObject;
                explosion.transform.parent = null;


                if (gameObjectTag == "Yellow" || gameObjectTag == "Green")
                {
                    player.transform.GetChild(6).gameObject.transform.GetChild(1).GetComponent<Animator>().SetTrigger("Active");
                    player.transform.GetChild(9).gameObject.SetActive(true);
                    player.transform.GetChild(4).gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 255, .13f);
                    player.transform.GetChild(4).gameObject.tag = "Blue";
                }
                else if (gameObjectTag == "Magenta" || gameObjectTag == "Red")
                {
                    player.transform.GetChild(4).gameObject.transform.GetChild(1).GetComponent<Animator>().SetTrigger("Active");
                    player.transform.GetChild(8).gameObject.SetActive(true);
                    // player.transform.GetChild(8).gameObject.GetComponent<SpriteRenderer>().enabled = true;
                    // player.transform.GetChild(8).gameObject.transform.GetChild(0).gameObject.SetActive(true);
                    // player.transform.GetChild(8).gameObject.transform.GetChild(1).gameObject.SetActive(true);
                    player.transform.GetChild(5).gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 255, 0, .13f);
                    player.transform.GetChild(5).gameObject.tag = "Green";
                }
                else if (gameObjectTag == "Cyan" || gameObjectTag == "Blue")
                {
                    player.transform.GetChild(5).gameObject.transform.GetChild(1).GetComponent<Animator>().SetTrigger("Active");
                    player.transform.GetChild(7).gameObject.SetActive(true);
                    player.transform.GetChild(6).gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, .13f);
                    player.transform.GetChild(6).gameObject.tag = "Red";
                }



                // yield return new WaitForSeconds(0.5f);
                player.transform.GetChild(1).gameObject.SetActive(false);
                player.transform.GetChild(2).gameObject.SetActive(false);
                player.transform.GetChild(3).gameObject.SetActive(false);

                explosion.GetComponent<Animator>().SetTrigger("Active");


                //   GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;

                GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().SetState("Line");


            }
            else if (player.GetComponent<PlayerMovement>().GetState() == "Line")
            {
                if (player.transform.GetChild(7).gameObject.activeSelf)
                {
                    player.GetComponent<PlayerMovement>().movementSpeed = 0;
                    player.GetComponent<PlayerMovement>().rotationSpeed = 0;
                    player.transform.GetChild(7).gameObject.GetComponent<Animator>().SetTrigger("Active");
                    //        player.transform.GetChild(7).gameObject.GetComponent<ZapOut>().Zap();
                    //player.transform.GetChild(7).gameObject.SetActive(false);
                }
                else if (player.transform.GetChild(8).gameObject.activeSelf)
                {
                    player.GetComponent<PlayerMovement>().movementSpeed = 0;
                    player.GetComponent<PlayerMovement>().rotationSpeed = 0;
                    player.transform.GetChild(8).gameObject.GetComponent<Animator>().SetTrigger("Active");
                    // player.transform.GetChild(8).gameObject.SetActive(false);
                }
                else if (player.transform.GetChild(9).gameObject.activeSelf)
                {
                    player.GetComponent<PlayerMovement>().movementSpeed = 0;
                    player.GetComponent<PlayerMovement>().rotationSpeed = 0;
                    player.transform.GetChild(9).gameObject.GetComponent<Animator>().SetTrigger("Active");
                    //    player.transform.GetChild(9).gameObject.GetComponent<ZapOut>().Zap();
                    //player.transform.GetChild(9).gameObject.SetActive(false);
                }

                if (player.transform.GetChild(4).gameObject.activeSelf)
                {
                    if (player.transform.GetChild(5).gameObject.activeSelf)
                    {
                        if (Vector3.Distance(player.transform.GetChild(4).gameObject.transform.position, collider.gameObject.transform.position)
                            > Vector3.Distance(player.transform.GetChild(5).gameObject.transform.position, collider.gameObject.transform.position))
                        {
                            player.transform.GetChild(5).gameObject.transform.GetChild(1).GetComponent<Animator>().SetTrigger("Active");
                            player.transform.GetChild(4).gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, .13f);
                            player.transform.GetChild(4).gameObject.tag = "White";
                        }
                        else
                        {
                            player.transform.GetChild(4).gameObject.transform.GetChild(1).GetComponent<Animator>().SetTrigger("Active");
                            player.transform.GetChild(5).gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, .13f);
                            player.transform.GetChild(5).gameObject.tag = "White";
                        }
                    }
                    else
                    {
                        if (Vector3.Distance(player.transform.GetChild(4).gameObject.transform.position, collider.gameObject.transform.position)
                            > Vector3.Distance(player.transform.GetChild(6).gameObject.transform.position, collider.gameObject.transform.position))
                        {
                            player.transform.GetChild(6).gameObject.transform.GetChild(1).GetComponent<Animator>().SetTrigger("Active");
                            player.transform.GetChild(4).gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, .13f);
                            player.transform.GetChild(4).gameObject.tag = "White";
                        }
                        else
                        {
                            player.transform.GetChild(4).gameObject.transform.GetChild(1).GetComponent<Animator>().SetTrigger("Active");
                            player.transform.GetChild(6).gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, .13f);
                            player.transform.GetChild(6).gameObject.tag = "White";
                        }
                    }
                }
                else
                {
                    if (Vector3.Distance(player.transform.GetChild(6).gameObject.transform.position, collider.gameObject.transform.position)
                        > Vector3.Distance(player.transform.GetChild(5).gameObject.transform.position, collider.gameObject.transform.position))
                    {
                        player.transform.GetChild(5).gameObject.transform.GetChild(1).GetComponent<Animator>().SetTrigger("Active");
                        player.transform.GetChild(6).gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, .13f);
                        player.transform.GetChild(6).gameObject.tag = "White";
                    }
                    else
                    {
                        player.transform.GetChild(6).gameObject.transform.GetChild(1).GetComponent<Animator>().SetTrigger("Active");
                        player.transform.GetChild(5).gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, .13f);
                        player.transform.GetChild(5).gameObject.tag = "White";
                    }
                }
                //    yield return new WaitForSeconds(0.0f);

                GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().SetState("Dot");
            }
            else if (player.GetComponent<PlayerMovement>().GetState() == "Dot")
            {
                if (player.transform.GetChild(4).gameObject.activeSelf)
                {
                    player.GetComponent<PlayerMovement>().movementSpeed = 0;
                    player.GetComponent<PlayerMovement>().rotationSpeed = 0;
                    player.transform.GetChild(4).gameObject.transform.GetChild(1).GetComponent<Animator>().SetTrigger("Active");
                }
                if (player.transform.GetChild(5).gameObject.activeSelf)
                {
                    player.GetComponent<PlayerMovement>().movementSpeed = 0;
                    player.GetComponent<PlayerMovement>().rotationSpeed = 0;
                    player.transform.GetChild(5).gameObject.transform.GetChild(1).GetComponent<Animator>().SetTrigger("Active");
                }

                if (player.transform.GetChild(6).gameObject.activeSelf)
                {
                    player.GetComponent<PlayerMovement>().movementSpeed = 0;
                    player.GetComponent<PlayerMovement>().rotationSpeed = 0;
                    player.transform.GetChild(6).gameObject.transform.GetChild(1).GetComponent<Animator>().SetTrigger("Active");
                }
            }
        }
      //  yield return new WaitForSeconds(0.0f);
    }

    IEnumerator Reactivate()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;

        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().SetState("Line");
    }


}

/**

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZapOut : MonoBehaviour
{
    public void Zap()
    {
        while (transform.localScale.x > 0)
        {
            gameObject.transform.localScale = new Vector3(-.1f, .1f, 0);
        }
        gameObject.SetActive(false);
    }
}

**/

