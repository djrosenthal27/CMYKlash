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
    

    IEnumerator OnTriggerEnter2D(Collider2D collider)
    {
        string colliderTag = collider.gameObject.tag;
        string gameObjectTag = this.gameObject.tag;
        if ((colliderTag == "Yellow" && (gameObjectTag == "Yellow" || gameObjectTag == "Red" || gameObjectTag == "Green"))
            || (colliderTag == "Magenta" && (gameObjectTag == "Magenta" || gameObjectTag == "Red" || gameObjectTag == "Blue"))
            || (colliderTag == "Cyan" && (gameObjectTag == "Cyan" || gameObjectTag == "Blue" || gameObjectTag == "Green")))
        {
            collider.gameObject.SetActive(false);

        } else
        {
            if (GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().GetState() == "Triangle")
            {
                Debug.Log("Tri");
                GameObject.FindWithTag("Player").transform.GetChild(0).gameObject.SetActive(false);
                GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
                GameObject.FindWithTag("Player").transform.GetChild(1).gameObject.GetComponent<Animator>().SetTrigger("Active");
                GameObject.FindWithTag("Player").transform.GetChild(1).parent = null;
                yield return new WaitForSeconds(0.5f);
                GameObject.FindWithTag("Player").transform.GetChild(1).gameObject.SetActive(false);
                GameObject.FindWithTag("Player").transform.GetChild(2).gameObject.SetActive(false);
                GameObject.FindWithTag("Player").transform.GetChild(3).gameObject.SetActive(false);
                GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;

                if (gameObjectTag == "Yellow" || gameObjectTag == "Green")
                {
                    GameObject.FindWithTag("Player").transform.GetChild(6).gameObject.SetActive(false);
                    GameObject.FindWithTag("Player").transform.GetChild(4).gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 255, .13f);
                    GameObject.FindWithTag("Player").transform.GetChild(4).gameObject.tag = "Blue";
                }
                if (gameObjectTag == "Magenta" || gameObjectTag == "Red")
                {
                    GameObject.FindWithTag("Player").transform.GetChild(4).gameObject.SetActive(false);
                    GameObject.FindWithTag("Player").transform.GetChild(5).gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 255, 0, .13f);
                    GameObject.FindWithTag("Player").transform.GetChild(5).gameObject.tag = "Green";
                }
                if (gameObjectTag == "Cyan" || gameObjectTag == "Blue")
                {
                    GameObject.FindWithTag("Player").transform.GetChild(5).gameObject.SetActive(false);
                    GameObject.FindWithTag("Player").transform.GetChild(6).gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, .13f);
                    GameObject.FindWithTag("Player").transform.GetChild(6).gameObject.tag = "Red";
                }

                GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().SetState("Line");

            } else if (GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().GetState() == "Line")
            {
                Debug.Log("Li1");
                yield return new WaitForSeconds(3f);
                Debug.Log("Li2");
            }
        }
        yield return new WaitForSeconds(0.0f);
    }

}
